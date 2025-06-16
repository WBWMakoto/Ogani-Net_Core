using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data; // Adjust namespace for your DbContext
using WebApplication1.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data.Entities;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ManageAppDbContext _context;
        private readonly UserManager<ManageUser> _userManager;

        public HomeController(ManageAppDbContext context, UserManager<ManageUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var viewModel = new DashboardViewModel
            {
                TotalRevenue = await _context.Orders.SumAsync(o => o.TotalAmount),
                NumberOfOrders = await _context.Orders.CountAsync(),
                AverageOrderValue = await _context.Orders.AnyAsync() ? await _context.Orders.AverageAsync(o => o.TotalAmount) : 0,
                TopProducts = await (from od in _context.OrderDetails
                                     join p in _context.Products on od.ProductId equals p.Id
                                     group od by new { p.Id, p.Name } into g
                                     select new TopProductViewModel
                                     {
                                         ProductId = g.Key.Id,
                                         ProductName = g.Key.Name,
                                         Revenue = g.Sum(od => od.Quantity * od.UnitPrice)
                                     })
                                     .OrderByDescending(x => x.Revenue)
                                     .Take(5)
                                     .ToListAsync(),
                TopCategories = await (from od in _context.OrderDetails
                                       join p in _context.Products on od.ProductId equals p.Id
                                       join c in _context.Categories on p.CategoryId equals c.Id
                                       group od by new { c.Id, c.Name } into g
                                       select new TopCategoryViewModel
                                       {
                                           CategoryId = g.Key.Id,
                                           CategoryName = g.Key.Name,
                                           Revenue = g.Sum(od => od.Quantity * od.UnitPrice)
                                       })
                                       .OrderByDescending(x => x.Revenue)
                                       .Take(5)
                                       .ToListAsync(),
                TopOrders = await _context.Orders
                                     .OrderByDescending(o => o.TotalAmount)
                                     .Take(5)
                                     .Select(o => new TopOrderViewModel
                                     {
                                         OrderId = o.Id,
                                         TotalAmount = o.TotalAmount,
                                         UserName = o.UserId
                                     })
                                     .ToListAsync(),
                OrderStatusDistribution = await _context.Orders
                                     .GroupBy(o => o.Status)
                                     .Select(g => new OrderStatusViewModel
                                     {
                                         Status = g.Key,
                                         Count = g.Count()
                                     })
                                     .ToListAsync(),
                SalesOverTime = await _context.Orders
    .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
    .Select(g => new SalesOverTimeViewModel
    {
        Date = EF.Functions.DateFromParts(g.Key.Year, g.Key.Month, 1),
        Revenue = g.Sum(o => o.TotalAmount)
    })
    .OrderBy(e0 => e0.Date)
    .ToListAsync(),
                NumberOfBlogPosts = await _context.BlogPosts.CountAsync(),
                NumberOfComments = await _context.Comments.CountAsync(),
                MostCommentedBlogPosts = await _context.BlogPosts
                                     .OrderByDescending(b => b.Comments.Count)
                                     .Take(5)
                                     .Select(b => new MostCommentedBlogPostViewModel
                                     {
                                         BlogPostId = b.Id,
                                         Title = b.Title,
                                         CommentCount = b.Comments.Count
                                     })
                                     .ToListAsync(),
                NumberOfCustomers = await _userManager.Users.CountAsync(), // Giả sử bạn có DbSet<User>
                NumberOfProducts = await _context.Products.CountAsync(),
                OrdersThisMonth = await _context.Orders
                    .Where(o => o.OrderDate.Year == DateTime.Now.Year && o.OrderDate.Month == DateTime.Now.Month)
                    .CountAsync()
            };

            return View(viewModel);
        }
    }
}