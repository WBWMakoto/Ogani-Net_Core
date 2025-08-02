using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ManageAppDbContext _context;
        private readonly IVnPayService _vnPayService;
        private readonly UserManager<ManageUser> _userManager;

        public CheckOutController(ManageAppDbContext context, IVnPayService vnPayService, UserManager<ManageUser> userManager)
        {
            _context = context;
            _vnPayService = vnPayService;
            _userManager = userManager;
        }

        // Hiển thị trang checkout
        public IActionResult Index()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return RedirectToAction("Index", "Cart");
            }

            var cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            return View(cart);
        }

        // Xử lý thanh toán với VNPay hoặc QR Code
        [HttpPost]
        public async Task<IActionResult> Checkout(string firstName, string lastName, string country, string address, string address2, string city, string phone, string email, string orderNotes, string paymentMethod, string orderDescription)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson))
            {
                return Json(new { success = false, message = "Cart data not found." });
            }

            var cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            if (cart == null || !cart.Any())
            {
                return Json(new { success = false, message = "Your cart is empty." });
            }

            var totalAmount = cart.Sum(i => i.Price * i.Quantity); // Tính lại totalAmount
            var orderId = DateTime.Now.Ticks.ToString(); // Dùng ticks làm orderId, khớp với VnPayService

            var order = new Order
            {
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                Address = address,
                Address2 = address2,
                City = city,
                Phone = phone,
                Email = email,
                OrderNotes = orderNotes,
                PaymentMethod = paymentMethod,
                TotalAmount = totalAmount,
                OrderDetails = cart.Select(item => new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                }).ToList()
            };

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));
            HttpContext.Session.SetString("Cart", cartJson);
            HttpContext.Session.SetString("OrderId", orderId);

            if (paymentMethod == "vnpay")
            {
                // Tính số tiền theo định dạng VNPay: nhân 100 và làm tròn thành số nguyên
                var vnpayAmount = (long)Math.Round(totalAmount * 100); // Làm tròn để tránh lỗi với phần thập phân

                // Tạo thông tin thanh toán
                var paymentInfo = new PaymentInformationModel
                {
                    Name = $"{firstName} {lastName}",
                    OrderDescription = $"Thanh toán đơn hàng {orderId}",
                    Amount = vnpayAmount, // Số tiền đã nhân 100
                    OrderType = "topup" // Đảm bảo giá trị hợp lệ
                };

                // Tạo URL thanh toán VNPay
                var paymentUrl = _vnPayService.CreatePaymentUrl(paymentInfo, HttpContext);

                return Json(new { success = true, paymentUrl });
            }
            else if (paymentMethod == "qrcode")
            {
                // Tạo transaction cho QR Code
                var transaction = new Transaction
                {
                    OrderDescription = orderDescription,
                    Amount = totalAmount,
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                // Tạo URL mã QR
                const string accountNo = "0702775390";
                const string accountName = "PHANNGOCTHUONG";
                long qrAmount = (long)Math.Round(totalAmount);
                var qrUrl = $"https://img.vietqr.io/image/MB-{accountNo}-qr_only.png?amount={qrAmount}&accountName={Uri.EscapeDataString(accountName)}&addInfo={Uri.EscapeDataString(orderDescription)}";

                return Json(new { success = true, transactionId = transaction.Id, qrUrl, totalTime = 5 * 60 }); // Trả về transactionId, URL mã QR và thời gian đếm ngược (5 phút)
            }

            return Json(new { success = false, message = "Invalid payment method." });
        }

        [HttpPost]
        public async Task<IActionResult> CheckQRPayment(int transactionId, int remainingTime)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);
            if (transaction == null)
            {
                return Json(new { success = false, message = "Transaction not found." });
            }

            if (remainingTime <= 0)
            {
                if (transaction.Status != "Success")
                {
                    transaction.Status = "Expired";
                    transaction.UpdatedAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                return Json(new { success = false, message = "Thời gian thanh toán đã hết. Vui lòng thử lại!", status = "expired", remainingTime = 0 });
            }

            const string checkUrl = "https://script.googleusercontent.com/macros/echo?user_content_key=AehSKLhc7HnuntFvIgX33QOpR5H6IEu4pNczGDW3PNGQMCdHvpM3UqNLLRCou3rZ7tyGw5G1_MP9vpnFhDZXwi3SRDXcA-zUXDXmudzqS0ZdbaGySlvOAwFE5tx-yMmHKgTmgSugqAPfS8nFWJr-zTOx2FthAhZ4VSprPVzEj4SZQ6ak42NByE7-MEZmRjQ65NyyVmMXUyMIjkVd5UU8QkrW1IJOfDmllFha-dvnf9-MRI3QdK7wP_-eS255yc2jAJWVJ5MWwHYaUxNClSH5sruBsYN1bci0UA&lib=M_4gvyoaq79SGqdxdq4W8ONe8DhPhAC8H";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(checkUrl);
            if (!response.IsSuccessStatusCode)
            {
                return Json(new { success = false, message = "Failed to check payment status.", status = "pending", remainingTime });
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
            var rows = data.data;

            bool paymentFound = false;
            foreach (var row in rows)
            {
                string description = row.description?.ToString() ?? "";
                decimal amount = row["Số tiền"] ?? 0;

                if (description.Contains(transaction.OrderDescription) && amount == transaction.Amount)
                {
                    paymentFound = true;
                    break;
                }
            }

            if (paymentFound)
            {
                transaction.Status = "Success";
                transaction.UpdatedAt = DateTime.Now;

                var cartJson = HttpContext.Session.GetString("Cart");
                var orderJson = HttpContext.Session.GetString("Order");
                if (string.IsNullOrEmpty(cartJson) || string.IsNullOrEmpty(orderJson))
                {
                    return Json(new { success = false, message = "Cart or order data not found.", status = "error", remainingTime });
                }

                var cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
                var order = JsonConvert.DeserializeObject<Order>(orderJson);
                var user = await _userManager.GetUserAsync(User);

                order.UserId = user.Id;
                order.OrderDate = DateTime.Now;
                order.Status = "Pending";
                order.OrderDetails = cart.Select(item => new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                }).ToList();

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                transaction.OrderId = order.Id;
                await _context.SaveChangesAsync();

                HttpContext.Session.Remove("Cart");
                HttpContext.Session.Remove("Order");
                HttpContext.Session.Remove("OrderId");

                return Json(new { success = true, message = "Thanh toán thành công! Đơn hàng của bạn đã được tạo!", status = "success", remainingTime });
            }

            return Json(new { success = false, message = "Đang chờ thanh toán...", status = "pending", remainingTime });
        }

        [HttpGet]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
            try
            {
                var response = _vnPayService.PaymentExecute(Request.Query);

                Console.WriteLine($"VNPay Callback - Success: {response.Success}, VnPayResponseCode: {response.VnPayResponseCode}, OrderId: {response.OrderId}");

                if (!response.Success || response.VnPayResponseCode != "00")
                {
                    return Json(new
                    {
                        success = false,
                        message = response.Success
                            ? $"Payment failed. VNPay Response Code: {response.VnPayResponseCode}"
                            : "Payment failed. Invalid signature.",
                        response
                    });
                }

                var cartJson = HttpContext.Session.GetString("Cart");
                var orderJson = HttpContext.Session.GetString("Order");
                if (string.IsNullOrEmpty(cartJson) || string.IsNullOrEmpty(orderJson))
                {
                    return Json(new
                    {
                        success = false,
                        message = "Cart or order data not found.",
                        response
                    });
                }

                var cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
                var order = JsonConvert.DeserializeObject<Order>(orderJson);
                var user = await _userManager.GetUserAsync(User);

                order.UserId = user.Id;
                order.OrderDate = DateTime.Now;
                order.Status = "Pending";
                order.OrderDetails = cart.Select(item => new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                }).ToList();

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Xóa dữ liệu trong Session
                HttpContext.Session.Remove("Cart");
                HttpContext.Session.Remove("Order");
                HttpContext.Session.Remove("OrderId");

                return View("PaymentResult", new PaymentResultViewModel
                {
                    Success = true,
                    Message = "Payment successful! Your order has been placed.",
                    OrderId = order.Id
                });
            }
            catch (Exception)
            {
                return View("PaymentResult", new PaymentResultViewModel
                {
                    Success = false,
                    Message = "An error occurred while processing your payment. Please try again later."
                });
            }
        }

    }
}