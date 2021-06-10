using System.Collections;
using System.Collections.Generic;
using BlogManagement.Core.Domain.Posts;
using Golrang.Framework.Domain;

namespace BlogManagement.Core.Domain.Blogs
{
    public class Blog: BaseEntity
    {
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Desciption { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
