using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Main image URL is required")]
        public string ImageUrl { get; set; } // Ảnh chính

        [Required]
        public int CategoryId { get; set; }

        public List<string> SubImageUrls { get; set; } = new List<string>(); // Danh sách link ảnh phụ
        public List<ProductImage> ExistingSubImages { get; set; } = new List<ProductImage>(); // Ảnh phụ hiện có (dùng khi chỉnh sửa)
    }
}
