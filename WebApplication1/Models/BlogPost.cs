using System.Collections.Generic;
using System;

namespace WebApplication1.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } // Tiêu đề bài viết
        public string Content { get; set; } // Nội dung bài viết
        public string ImageUrl { get; set; } // Hình ảnh bài viết
        public DateTime CreatedDate { get; set; } // Ngày tạo bài viết
        public string Author { get; set; } // Tác giả
        public List<Comment> Comments { get; set; } // Danh sách bình luận
    }
}
