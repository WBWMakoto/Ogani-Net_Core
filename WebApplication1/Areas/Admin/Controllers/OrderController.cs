using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly ManageAppDbContext _context;

        public OrderController(ManageAppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ToListAsync();
            return View(orders);
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Details: Id is null.");
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                Console.WriteLine($"Details: Order with Id {id} not found.");
                return NotFound();
            }

            Console.WriteLine($"Details: Found order with Id {id}, Status: {order.Status}");
            return View(order);
        }

        // POST: Admin/Order/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            Console.WriteLine($"UpdateStatus called - Id: {id}, Status: {status}");

            if (id <= 0)
            {
                Console.WriteLine("UpdateStatus: Invalid Id.");
                return Json(new { success = false, message = "ID đơn hàng không hợp lệ." });
            }

            if (string.IsNullOrEmpty(status))
            {
                Console.WriteLine("UpdateStatus: Status is null or empty.");
                return Json(new { success = false, message = "Vui lòng chọn trạng thái." });
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                Console.WriteLine($"UpdateStatus: Order with Id {id} not found.");
                return Json(new { success = false, message = "Không tìm thấy đơn hàng." });
            }

            var validStatuses = new List<string> { "Pending", "Shipped", "Delivered", "Cancelled" };
            if (!validStatuses.Contains(status))
            {
                Console.WriteLine($"UpdateStatus: Invalid status: {status}");
                return Json(new { success = false, message = "Trạng thái không hợp lệ." });
            }

            try
            {
                order.Status = status;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                Console.WriteLine($"UpdateStatus: Order status updated to: {status}");
                return Json(new { success = true, message = "Cập nhật trạng thái thành công!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateStatus: Error saving changes: {ex.Message}");
                return Json(new { success = false, message = "Có lỗi xảy ra khi cập nhật trạng thái: " + ex.Message });
            }
        }
    }
}