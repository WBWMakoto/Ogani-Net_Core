using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.Entities;
using System;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ManageAppDbContext _context;
        private readonly UserManager<ManageUser> _userManager;

        public OrderController(ManageAppDbContext context, UserManager<ManageUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Order/Index
        public async Task<IActionResult> Index(string status)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var ordersQuery = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.UserId == user.Id);

            if (!string.IsNullOrEmpty(status))
            {
                ordersQuery = ordersQuery.Where(o => o.Status == status);
            }

            var orders = await ordersQuery.ToListAsync();

            var statuses = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Tất cả" },
                new SelectListItem { Value = "Pending", Text = "Pending" },
                new SelectListItem { Value = "Shipped", Text = "Shipped" },
                new SelectListItem { Value = "Delivered", Text = "Delivered" },
                new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
            };

            ViewBag.Statuses = statuses;
            ViewBag.SelectedStatus = status;

            return View(orders);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/SubmitReview
        [HttpPost]
        public async Task<IActionResult> SubmitReview(int productId, int orderDetailId, int rating, string comment)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra orderDetailId có hợp lệ và thuộc về người dùng không
            var orderDetail = await _context.OrderDetails
                .Include(od => od.Order)
                .FirstOrDefaultAsync(od => od.Id == orderDetailId && od.Order.UserId == user.Id);

            if (orderDetail == null || orderDetail.IsComment)
            {
                return BadRequest("Không thể đánh giá sản phẩm này.");
            }

            // Lưu đánh giá (giả sử có bảng Review)
            var review = new Review
            {
                ProductId = productId,
                UserId = user.Id,
                Rating = rating,
                Comment = comment,
            };

            _context.Reviews.Add(review);

            // Cập nhật IsComment = true
            orderDetail.IsComment = true;

            await _context.SaveChangesAsync();

            // Tính lại Rating của sản phẩm
            var product = await _context.Products
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product != null)
            {
                var totalRating = product.Reviews.Sum(r => r.Rating); // Tổng điểm đánh giá
                var numberOfReviews = product.Reviews.Count; // Số lượng đánh giá
                product.Rating = numberOfReviews > 0 ? (double)totalRating / numberOfReviews : 0; // Tính trung bình

                // Lưu Rating mới
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = orderDetail.OrderId });
        }
    }
}