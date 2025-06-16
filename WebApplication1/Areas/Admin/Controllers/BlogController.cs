using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ManageAppDbContext _context;

        public BlogController(ManageAppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Blog
        public async Task<IActionResult> Index()
        {
            var blog = await _context.BlogPosts.ToListAsync();
            return View(blog);
        }

        // GET: Admin/Blog/Details/5
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

        // GET: Admin/Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.CreatedDate = DateTime.Now;
                blogPost.Author = User.Identity.Name ?? "Admin";

                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            var viewModel = BlogViewModel.FromBlogPost(blogPost);
            return View(viewModel);
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBlogPost = await _context.BlogPosts.FindAsync(id);
                    if (existingBlogPost == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật BlogPost từ ViewModel
                    viewModel.UpdateBlogPost(existingBlogPost);

                    _context.Update(existingBlogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blogPost != null)
            {
                // Xóa các bình luận liên quan trước
                if (blogPost.Comments != null && blogPost.Comments.Any())
                {
                    _context.Comments.RemoveRange(blogPost.Comments);
                }

                _context.BlogPosts.Remove(blogPost);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Blog/CreateComment/5 (Tạo bình luận mới cho bài viết)
        public IActionResult CreateComment(int blogPostId)
        {
            var comment = new Comment
            {
                BlogPostId = blogPostId,
                CreatedDate = DateTime.Now
            };
            return View(comment);
        }

        // POST: Admin/Blog/CreateComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreatedDate = DateTime.Now;
                comment.UserId = User.Identity.Name ?? "Admin"; // Gán người dùng hiện tại

                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = comment.BlogPostId });
            }
            return View(comment);
        }

        // GET: Admin/Blog/EditComment/5
        public async Task<IActionResult> EditComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Admin/Blog/EditComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingComment = await _context.Comments.FindAsync(id);
                    if (existingComment == null)
                    {
                        return NotFound();
                    }

                    existingComment.Content = comment.Content;
                    existingComment.CreatedDate = comment.CreatedDate;
                    existingComment.UserId = comment.UserId;

                    _context.Update(existingComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Comments.Any(e => e.Id == comment.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Details), new { id = comment.BlogPostId });
            }
            return View(comment);
        }

        // GET: Admin/Blog/DeleteComment/5
        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.BlogPost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Admin/Blog/DeleteComment/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCommentConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                var blogPostId = comment.BlogPostId;
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = blogPostId });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}