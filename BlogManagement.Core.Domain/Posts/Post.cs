using BlogManagement.Core.Domain.Comments;
using Golrang.Framework.Domain;
using System;
using System.Collections.Generic;

namespace BlogManagement.Core.Domain.Posts
{
    public class Post: BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
