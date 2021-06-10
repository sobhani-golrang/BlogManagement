using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Infra.Data.Sql.Common;
using Golrang.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infra.Data.Sql.Blogs
{
    public class EfBlogRepository : EfBaseRepository<Blog>, BlogRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;
        public EfBlogRepository(BlogManagementDbContext blogManagementDb) : base(blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
    }
}
