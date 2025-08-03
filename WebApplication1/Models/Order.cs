using System.Collections.Generic;
using System;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Khóa ngoại liên kết với người dùng (IdentityUser hoặc ManageUser)
        public DateTime OrderDate { get; set; } // Ngày đặt hàng
        public decimal TotalAmount { get; set; } // Tổng tiền đơn hàng
        public string Status { get; set; } // Trạng thái đơn hàng (VD: Pending, Shipped, Delivered)

        public string FirstName { get; set; } // Tên
        public string LastName { get; set; } // Họ
        public string Country { get; set; } // Quốc gia
        public string Address { get; set; } // Địa chỉ (Street Address)
        public string Address2 { get; set; } // Địa chỉ bổ sung (Apartment, suite, v.v.)
        public string City { get; set; } // Thị trấn/Thành phố
        public string Phone { get; set; } // Số điện thoại
        public string Email { get; set; } // Email
        public string OrderNotes { get; set; } // Ghi chú đặt hàng
        public string PaymentMethod { get; set; } // Phương thức thanh toán (VD: vnpay, qrcode)
        public List<OrderDetail> OrderDetails { get; set; } // Danh sách chi tiết đơn hàng
    }
}
