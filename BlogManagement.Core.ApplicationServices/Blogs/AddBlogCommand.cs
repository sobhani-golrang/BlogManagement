using BlogManagement.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Core.ApplicationServices.Blogs
{
    public class AddBlogCommand
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string EnName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Desciption { get; set; }

        public Blog ToBlog() => new Blog
        {
            Name = this.Name,
            Desciption = this.Desciption,
            EnName = this.EnName
        };

    }
}
