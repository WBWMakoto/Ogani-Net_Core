using System;

namespace WebApplication1.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; }

        // Hàm để ánh xạ từ BlogPost sang BlogViewModel
        public static BlogViewModel FromBlogPost(BlogPost blogPost)
        {
            return new BlogViewModel
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                ImageUrl = blogPost.ImageUrl,
                CreatedDate = blogPost.CreatedDate,
                Author = blogPost.Author
            };
        }

        // Hàm để cập nhật BlogPost từ BlogViewModel
        public void UpdateBlogPost(BlogPost blogPost)
        {
            blogPost.Title = Title ?? blogPost.Title;
            blogPost.Content = Content ?? blogPost.Content;
            blogPost.ImageUrl = ImageUrl ?? blogPost.ImageUrl;
            blogPost.Author = Author ?? blogPost.Author;
            blogPost.CreatedDate = CreatedDate != default ? CreatedDate : blogPost.CreatedDate;
        }
    }
}