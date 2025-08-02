using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly ManageAppDbContext _context;
        private readonly IVnPayService _vnPayService;

        public CartController(ManageAppDbContext context, IVnPayService vnPayService)
        {
            _context = context;
            _vnPayService = vnPayService;
        }

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = quantity
                });
            }

            SaveCart(cart);

            // Tính số lượng mặt hàng và tổng tiền
            var cartCount = cart.Count; // Số lượng mặt hàng
            var totalQuantity = cart.Sum(item => item.Quantity); // Tổng số lượng sản phẩm
            var cartTotal = cart.Sum(item => item.Price * item.Quantity); // Tổng tiền

            // Định dạng cartTotal theo kiểu Việt Nam
            string formattedCartTotal = cartTotal % 1 == 0
                ? cartTotal.ToString("#,##0")
                : cartTotal.ToString("#,##0.##");

            // Nếu là yêu cầu AJAX, trả về JSON
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new
                {
                    success = true,
                    message = $"{product.Name} đã thêm vào giỏ!",
                    cartCount = cartCount,
                    totalQuantity = totalQuantity,
                    cartTotal = formattedCartTotal // Đã định dạng
                });
            }

            return RedirectToAction("Index");
        }

        // Xóa sản phẩm khỏi giỏ hàng
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem == null)
            {
                return Json(new { success = false, message = "Product not found in cart" });
            }

            cart.Remove(cartItem);
            SaveCart(cart);

            var cartCount = cart.Sum(item => item.Quantity);
            var cartTotal = cart.Sum(item => item.Price * item.Quantity);

            return Json(new
            {
                success = true,
                message = "Đã xoá sản phẩm ra khỏi giỏ!",
                cartCount = cartCount,
                cartTotal = cartTotal
            });
        }

        // Cập nhật số lượng sản phẩm
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem == null)
            {
                return Json(new { success = false, message = "Product not found in cart" });
            }

            if (quantity <= 0)
            {
                cart.Remove(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            SaveCart(cart);

            var itemTotal = cartItem != null ? cartItem.Price * cartItem.Quantity : 0;
            var cartCount = cart.Sum(item => item.Quantity);
            var cartTotal = cart.Sum(item => item.Price * item.Quantity);

            return Json(new
            {
                success = true,
                message = "cập nhật giỏ hàng!",
                itemTotal = itemTotal,
                cartCount = cartCount,
                cartTotal = cartTotal
            });
        }

        // Lấy giỏ hàng từ Session
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }

        // Lưu giỏ hàng vào Session
        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }

        private void ClearCart()
        {
            HttpContext.Session.Remove("Cart");
        }

        [HttpPost]
        public IActionResult PrepareCheckout()
        {
            var cart = GetCart();
            if (cart == null || !cart.Any())
            {
                return Json(new { success = false, message = "Your cart is empty." });
            }

            // Lưu giỏ hàng vào TempData để truyền sang CheckOutController
            TempData["Cart"] = JsonConvert.SerializeObject(cart);

            return Json(new { success = true });
        }
    }
}