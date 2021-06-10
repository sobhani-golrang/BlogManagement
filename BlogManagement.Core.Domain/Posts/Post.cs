using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.PostViews;
using Golrang.Framework.Domain;
using System;
using System.Collections.Generic;

namespace BlogManagement.Core.Domain.Posts
{
    public class Post: BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int BlogId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostView> PostViews { get; set; }
    }
}
