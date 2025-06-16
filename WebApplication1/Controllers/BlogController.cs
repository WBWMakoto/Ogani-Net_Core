using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        private readonly ManageAppDbContext _context;

        public BlogController(ManageAppDbContext context)
        {
            _context = context;
        }
        // GET: Blog/Index
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 6; // Số bài viết mỗi trang
            var blogPosts = _context.BlogPosts
                .Include(b => b.Comments)
                .OrderByDescending(b => b.CreatedDate); // Sắp xếp theo ngày tạo, mới nhất trước

            // Tính tổng số bài viết
            int totalPosts = await blogPosts.CountAsync();

            // Tính tổng số trang
            int totalPages = (int)Math.Ceiling((double)totalPosts / pageSize);

            // Lấy danh sách bài viết cho trang hiện tại
            var pagedPosts = await blogPosts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Truyền dữ liệu phân trang vào ViewBag
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedPosts);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Blog/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int blogPostId, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ModelState.AddModelError("Content", "Bình luận không được để trống.");
            }

            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    BlogPostId = blogPostId,
                    Content = content,
                    UserId = User.Identity.Name ?? "Anonymous", // Lấy tên người dùng hoặc "Anonymous" nếu chưa đăng nhập
                    CreatedDate = DateTime.Now
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = blogPostId });
            }

            // Nếu có lỗi, trả về trang chi tiết với thông báo lỗi
            var blogPost = await _context.BlogPosts
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(m => m.Id == blogPostId);

            return View("Details", blogPost);
        }
    }
}