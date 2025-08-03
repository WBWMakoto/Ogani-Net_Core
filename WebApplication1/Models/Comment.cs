using System;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } // Nội dung bình luận
        public string UserId { get; set; } // Khóa ngoại liên kết với người dùng (IdentityUser hoặc ManageUser)
        public DateTime CreatedDate { get; set; } // Ngày bình luận
        public int BlogPostId { get; set; } // Khóa ngoại liên kết với BlogPost
        public BlogPost BlogPost { get; set; } // Bài viết blog
    }
}
