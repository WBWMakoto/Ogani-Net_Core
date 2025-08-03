using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using ExcelDataReader;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ManageAppDbContext _context;

        public ProductsController(ManageAppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            // Đếm tổng số sản phẩm
            var totalItems = await _context.Products.CountAsync();

            // Tính tổng số trang
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Đảm bảo page hợp lệ
            page = page < 1 ? 1 : page;
            page = page > totalPages ? totalPages : page;

            // Lấy danh sách sản phẩm cho trang hiện tại
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .OrderByDescending(p => p.Id) // Sắp xếp theo ID hoặc tiêu chí khác
                .Skip((page - 1) * pageSize) // Bỏ qua các sản phẩm của trang trước
                .Take(pageSize) // Lấy số lượng sản phẩm cho trang hiện tại
                .ToListAsync();

            // Tạo một ViewModel để chứa danh sách sản phẩm và thông tin phân trang
            var viewModel = new PaginatedList<Product>
            {
                Items = products,
                PageIndex = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalItems = totalItems
            };

            return View(viewModel);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            Console.WriteLine($"Categories Count: {categories.Count}");
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View(new ProductViewModel());
        }


        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                return View(model);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                iPrice = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                ProductImages = new List<ProductImage>()
            };

            if (model.SubImageUrls != null)
            {
                foreach (var subImageUrl in model.SubImageUrls.Where(url => !string.IsNullOrEmpty(url)))
                {
                    product.ProductImages.Add(new ProductImage { ImageUrl = subImageUrl });
                }
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                ExistingSubImages = product.ProductImages,
                SubImageUrls = new List<string>()
            };

            // Lấy danh sách danh mục và truyền trực tiếp vào ViewBag
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories; // Truyền danh sách danh mục thô

            // Debug: Kiểm tra danh sách danh mục
            Console.WriteLine($"Số lượng danh mục: {categories.Count}");
            foreach (var category in categories)
            {
                Console.WriteLine($"Danh mục ID: {category.Id}, Tên: {category.Name}");
            }

            return View(model);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var product = await _context.Products
                        .Include(p => p.ProductImages)
                        .FirstOrDefaultAsync(p => p.Id == id);

                    if (product == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật thông tin sản phẩm
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.ImageUrl = model.ImageUrl;
                    product.CategoryId = model.CategoryId;

                    // Xóa tất cả ảnh phụ cũ
                    if (product.ProductImages != null)
                    {
                        _context.ProductImages.RemoveRange(product.ProductImages);
                    }
                    product.ProductImages = new List<ProductImage>();

                    // Thêm lại tất cả ảnh phụ từ SubImageUrls (bao gồm cả ảnh cũ đã chỉnh sửa và ảnh mới)
                    if (model.SubImageUrls != null && model.SubImageUrls.Any(url => !string.IsNullOrEmpty(url)))
                    {
                        foreach (var subImageUrl in model.SubImageUrls.Where(url => !string.IsNullOrEmpty(url)))
                        {
                            product.ProductImages.Add(new ProductImage { ImageUrl = subImageUrl });
                        }
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.Id == model.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Nếu ModelState không hợp lệ, truyền lại danh sách danh mục
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View(model);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Xóa các ảnh phụ liên quan (nếu có)
            if (product.ProductImages != null && product.ProductImages.Any())
            {
                _context.ProductImages.RemoveRange(product.ProductImages);
            }

            // Xóa sản phẩm
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Products/DeleteSubImage/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubImage(int id)
        {
            var subImage = await _context.ProductImages.FindAsync(id);
            if (subImage == null)
            {
                return NotFound();
            }

            _context.ProductImages.Remove(subImage);
            await _context.SaveChangesAsync();

            // Lấy lại sản phẩm để hiển thị form chỉnh sửa
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == subImage.ProductId);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                ExistingSubImages = product.ProductImages,
                SubImageUrls = new List<string>()
            };

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> ApplyDiscount(int productId, string discountType, decimal discountValue, decimal iPrice, decimal currentPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại!" });
            }

            decimal newPrice = currentPrice;
            decimal newDiscount = 0;

            if (discountType == "percentage")
            {
                // Tính giá mới dựa trên iPrice và phần trăm giảm giá
                if (discountValue > 50)
                {
                    return Json(new { success = false, message = "Giảm giá theo phần trăm không được vượt quá 50%!" });
                }

                newDiscount = discountValue;
                newPrice = iPrice * (1 - (discountValue / 100));
            }
            else if (discountType == "fixed")
            {
                // Giảm trực tiếp số tiền từ giá hiện tại
                if (discountValue > currentPrice)
                {
                    return Json(new { success = false, message = "Số tiền giảm không được lớn hơn giá hiện tại!" });
                }

                newPrice = currentPrice - discountValue;
                // Tính lại phần trăm giảm giá dựa trên iPrice
                newDiscount = ((iPrice - newPrice) / iPrice) * 100;
            }
            else
            {
                return Json(new { success = false, message = "Kiểu giảm giá không hợp lệ!" });
            }

            // Cập nhật giá và phần trăm giảm giá của sản phẩm
            product.Price = newPrice;
            product.Discount = newDiscount;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Áp dụng giảm giá thành công!",
                newPrice = newPrice % 1 == 0 ? newPrice.ToString("#,##0") : newPrice.ToString("#,##0.##")
            });
        }
        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "Vui lòng chọn file Excel để upload." });
            }

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var table = result.Tables[0];

                        for (int i = 1; i < table.Rows.Count; i++) // Bỏ qua hàng header (hàng 0)
                        {
                            var row = table.Rows[i];

                            // Kiểm tra dữ liệu bắt buộc
                            if (row[0] == null || string.IsNullOrEmpty(row[0].ToString()) ||
                                row[2] == null || row[4] == null || row[5] == null)
                            {
                                continue; // Bỏ qua hàng thiếu dữ liệu
                            }

                            var product = new Product
                            {
                                Name = row[0].ToString(),
                                Description = row[1]?.ToString() ?? "",
                                Price = decimal.Parse(row[2].ToString()),
                                iPrice = decimal.Parse(row[3]?.ToString() ?? row[2].ToString()), // Nếu iPrice không có, dùng Price
                                ImageUrl = row[4].ToString(),
                                CategoryId = int.Parse(row[5].ToString()),
                                Discount = row[6] != null && !string.IsNullOrEmpty(row[6].ToString()) ? decimal.Parse(row[6].ToString()) : 0,
                                Rating = row[7] != null && !string.IsNullOrEmpty(row[7].ToString()) ? double.Parse(row[7].ToString()) : 0,
                                ProductImages = new List<ProductImage>()
                            };

                            // Xử lý ảnh phụ (SubImageUrls)
                            if (row[8] != null && !string.IsNullOrEmpty(row[8].ToString()))
                            {
                                var subImageUrls = row[8].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);
                                foreach (var url in subImageUrls)
                                {
                                    product.ProductImages.Add(new ProductImage { ImageUrl = url.Trim() });
                                }
                            }

                            _context.Products.Add(product);
                        }

                        await _context.SaveChangesAsync();
                        return Json(new { success = true, message = "Thêm sản phẩm từ Excel thành công!" });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi khi import Excel: {ex.Message}" });
            }
        }
    }
}
