using System.Threading.Tasks;
using BlogManagement.Core.Domain.PostViews;
using BlogManagement.Infra.Data.Sql.Common;
using Golrang.Framework.Data;

namespace BlogManagement.Infra.Data.Sql.PostViews
{
    public class EfPostViewRepository : EfBaseRepository<PostView>, PostViewRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;
        public EfPostViewRepository(BlogManagementDbContext blogManagementDb) : base(blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
    }
}