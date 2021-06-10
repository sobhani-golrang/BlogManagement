using System.Threading.Tasks;
using BlogManagement.Core.Domain.PostViews;
using BlogManagement.Infra.Data.Sql.Common;

namespace BlogManagement.Infra.Data.Sql.PostViews
{
    public class EfPostViewRepository : PostViewRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;
        public EfPostViewRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
        public async Task Add(PostView postView)
        {
            await _blogManagementDb.AddAsync(postView);
            await _blogManagementDb.SaveChangesAsync();
        }
    }
}