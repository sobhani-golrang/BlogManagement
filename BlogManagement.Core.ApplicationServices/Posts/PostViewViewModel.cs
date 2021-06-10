using System.Collections.Generic;
using BlogManagement.Core.Domain.Comments;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int BlogId { get; set; }
        public int? ViewCount { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}