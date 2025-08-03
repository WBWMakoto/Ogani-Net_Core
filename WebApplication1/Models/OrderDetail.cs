using System;

namespace WebApplication1.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Khóa ngoại liên kết với Order
        public Order Order { get; set; } // Đơn hàng
        public int ProductId { get; set; } // Khóa ngoại liên kết với Product
        public Product Product { get; set; } // Sản phẩm
        public int Quantity { get; set; } // Số lượng sản phẩm
        public decimal UnitPrice { get; set; } // Giá đơn vị tại thời điểm đặt hàng
        public Boolean IsComment { get; set; } = false;
    }
}
