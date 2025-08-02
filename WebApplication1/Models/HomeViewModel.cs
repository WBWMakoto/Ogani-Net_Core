using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> LatestProducts { get; set; }
        public List<Product> TopRatedProducts { get; set; }
        public List<Product> ReviewProducts { get; set; }
        public List<BlogPost> BlogPosts { get; set; } // Danh sách bài viết
    }
}