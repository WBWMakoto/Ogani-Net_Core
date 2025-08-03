using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } // Tên sản phẩm
        public string Description { get; set; } // Mô tả sản phẩm
        public decimal Price { get; set; } // Giá sản phẩm
        public decimal iPrice { get; set; } // Giá gốc sản phẩm
        public string ImageUrl { get; set; } // Đường dẫn hình ảnh
        public int CategoryId { get; set; } // Khóa ngoại liên kết với Category
        public decimal? Discount { get; set; } = 0;
        public Category Category { get; set; } // Danh mục của sản phẩm
        [Column(TypeName = "float")]
        public double Rating { get; set; } = 0;
        public List<ProductImage> ProductImages { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } // Danh sách chi tiết đơn hàng liên quan
        public List<Review> Reviews { get; set; }
    }
}
