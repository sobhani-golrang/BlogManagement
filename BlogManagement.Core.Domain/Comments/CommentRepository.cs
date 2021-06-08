using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.Comments
{
    public interface CommentRepository
    {
        Task Add(Comment comment);
    }
}