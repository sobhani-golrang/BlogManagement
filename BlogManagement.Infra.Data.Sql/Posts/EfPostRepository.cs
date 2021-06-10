using BlogManagement.Core.Domain.Posts;
using BlogManagement.Infra.Data.Sql.Common;
using Golrang.Framework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infra.Data.Sql.Posts
{
    public class EfPostRepository : EfBaseRepository<Post>, PostRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfPostRepository(BlogManagementDbContext blogManagementDb) : base(blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }

        public override Post Get(int postId)
        {
            return _blogManagementDb.Posts.Include(x => x.Comments).Include(x => x.PostViews).FirstOrDefault(c => c.Id == postId);
        }
    }
}
