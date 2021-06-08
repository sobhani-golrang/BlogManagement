using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Infra.Data.Sql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infra.Data.Sql.Blogs
{
    public class EfBlogRepository : BlogRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfBlogRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
        public void Add(Blog blog)
        {
            _blogManagementDb.Add(blog);
            _blogManagementDb.SaveChanges();
        }

        public Blog Get(int blogId)
        {
            return _blogManagementDb.Blogs.FirstOrDefault(c => c.Id == blogId);
        }

        public List<Blog> Get()
        {
            return _blogManagementDb.Blogs.ToList();
        }

        public void Remove(int blogId)
        {
            var blog = new Blog
            {
                Id = blogId
            };
            _blogManagementDb.Blogs.Remove(blog);
            _blogManagementDb.SaveChanges();
        }
    }
}
