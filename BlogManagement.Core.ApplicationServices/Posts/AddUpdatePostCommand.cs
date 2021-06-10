using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Core.Domain.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class AddUpdatePostCommand
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Body { get; set; }
        [Required]
        public int? BlogId { get; set; }

        public Post ToPost() => new Post
        {
            Title = Title,
            Body = Body,
            BlogId = BlogId.Value
        };

    }
}
