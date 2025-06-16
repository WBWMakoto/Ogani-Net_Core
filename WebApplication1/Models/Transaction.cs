using System;

namespace WebApplication1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string OrderDescription { get; set; } // Mã giao dịch (PNT + timestamp)
        public decimal Amount { get; set; } // Số tiền giao dịch
        public string Status { get; set; } // Trạng thái: Pending, Success, Expired
        public DateTime CreatedAt { get; set; } // Thời gian tạo
        public DateTime? UpdatedAt { get; set; } // Thời gian cập nhật
        public int? OrderId { get; set; } // Liên kết với đơn hàng (nếu thanh toán thành công)
        public Order Order { get; set; } // Quan hệ với Order
    }
}
