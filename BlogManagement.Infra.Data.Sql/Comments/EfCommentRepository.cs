using System.Threading.Tasks;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Infra.Data.Sql.Common;

namespace BlogManagement.Infra.Data.Sql.Comments
{
    public class EfCommentRepository : CommentRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;
        public EfCommentRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
        public async Task Add(Comment comment)
        {
            await _blogManagementDb.AddAsync(comment);
            await _blogManagementDb.SaveChangesAsync();
        }
    }
}