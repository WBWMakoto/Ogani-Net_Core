using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManageAppDbContext _context;

        public HomeController(ManageAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Categories = await _context.Categories.ToListAsync(),
                BlogPosts = await _context.BlogPosts
                    .Include(b => b.Comments) // Bao gồm danh sách bình luận
                    .OrderByDescending(b => b.CreatedDate) // Sắp xếp theo ngày tạo (mới nhất trước)
                    .Take(3) // Lấy 3 bài viết mới nhất
                    .ToListAsync(),
                Products = await _context.Products.Include(p => p.Category).ToListAsync(),
                LatestProducts = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .Take(9)
                .ToListAsync(),
                TopRatedProducts = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Rating)
                .Take(9)
                .ToListAsync(),
                ReviewProducts = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
            .OrderByDescending(p => _context.Reviews.Count(r => r.ProductId == p.Id))
            .Take(6)
            .ToListAsync()
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SearchSuggestions(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return Json(new List<object>());
            }

            // Tìm kiếm sản phẩm dựa trên Name hoặc Description
            var suggestions = await _context.Products
                .Where(p => p.Name.Contains(term) || (p.Description != null && p.Description.Contains(term)))
                .Select(p => new
                {
                    label = p.Name, // Tên hiển thị trong gợi ý
                    value = p.Id // Giá trị để sử dụng khi chọn (ID sản phẩm)
                })
                .Take(10) // Giới hạn số lượng gợi ý
                .ToListAsync();

            return Json(suggestions);
        }
    }
}
