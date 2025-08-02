using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Name { get; set; } // Tên danh mục (VD: Fresh Meat, Vegetables)
        public string Description { get; set; } // Mô tả danh mục
        public List<Product> Products { get; set; } // Danh sách sản phẩm thuộc danh mục
    }
}
