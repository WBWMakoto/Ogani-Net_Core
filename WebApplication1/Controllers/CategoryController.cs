using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ManageAppDbContext _context;

        public CategoryController(ManageAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int sort = 0, decimal? minPrice = null, decimal? maxPrice = null)
        {
            int pageSize = 9;
            var productsQuery = _context.Products.Include(p => p.Category).AsQueryable();

            if (minPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price <= maxPrice.Value);
            }

            // Sắp xếp dựa trên giá trị sort
            switch (sort)
            {
                case 1: // Price: Low to High
                    productsQuery = productsQuery.OrderBy(p => p.Price);
                    break;
                case 2: // Price: High to Low
                    productsQuery = productsQuery.OrderByDescending(p => p.Price);
                    break;
                default: // Default
                    productsQuery = productsQuery.OrderBy(p => p.Id);
                    break;
            }

            var products = await productsQuery.ToListAsync();
            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new CategoryViewModel
            {
                Categories = await _context.Categories.ToListAsync(),
                Products = pagedProducts,
                DiscountedProducts = await _context.Products
                    .Where(p => p.Discount.HasValue && p.Discount > 0)
                    .Take(6)
                    .ToListAsync(),
                LatestProducts = await _context.Products
                    .OrderByDescending(p => p.Id)
                    .Take(6)
                    .ToListAsync()
            };
            ViewBag.TotalPages = (int)Math.Ceiling(products.Count / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentSort = sort; // Lưu giá trị sort để giữ trạng thái
            ViewBag.MinPrice = minPrice ?? 0; // Giá trị mặc định nếu không có
            ViewBag.MaxPrice = maxPrice ?? 1000000; // Giá trị mặc định nếu không có
            return View(viewModel);
        }
    }
}
