using System;
using System.Collections.Generic;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TotalRevenue { get; set; }
        public int NumberOfOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public List<TopProductViewModel> TopProducts { get; set; }
        public List<TopCategoryViewModel> TopCategories { get; set; }
        public List<TopOrderViewModel> TopOrders { get; set; }
        public List<OrderStatusViewModel> OrderStatusDistribution { get; set; }
        public List<SalesOverTimeViewModel> SalesOverTime { get; set; }
        public int NumberOfBlogPosts { get; set; }
        public int NumberOfComments { get; set; }
        public List<MostCommentedBlogPostViewModel> MostCommentedBlogPosts { get; set; }
        // Thêm các thuộc tính mới
        public int NumberOfCustomers { get; set; }
        public int NumberOfProducts { get; set; }
        public int OrdersThisMonth { get; set; }
    }

    public class TopProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Revenue { get; set; }
    }

    public class TopCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Revenue { get; set; }
    }

    public class TopOrderViewModel
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserName { get; set; }
    }

    public class OrderStatusViewModel
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class SalesOverTimeViewModel
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
    }

    public class MostCommentedBlogPostViewModel
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public int CommentCount { get; set; }
    }
}