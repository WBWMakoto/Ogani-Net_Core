namespace WebApplication1.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } // Đường dẫn hình ảnh
        public int ProductId { get; set; } // Khóa ngoại liên kết với Product
        public Product Product { get; set; } // Sản phẩm liên quan
    }
}
