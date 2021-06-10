using System.Threading.Tasks;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Infra.Data.Sql.Common;
using Golrang.Framework.Data;

namespace BlogManagement.Infra.Data.Sql.Comments
{
    public class EfCommentRepository : EfBaseRepository<Comment>, CommentRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;
        public EfCommentRepository(BlogManagementDbContext blogManagementDb) : base(blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
    }
}