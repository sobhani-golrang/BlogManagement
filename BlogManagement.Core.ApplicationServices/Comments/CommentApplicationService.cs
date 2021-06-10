using System.Threading.Tasks;
using BlogManagement.Core.Domain.Comments;

namespace BlogManagement.Core.ApplicationServices.Comments
{
    public class CommentApplicationService
    {
        private readonly CommentRepository _commentRepository;
        public CommentApplicationService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Add(AddCommentCommand commentCommand)
        {
            await _commentRepository.AddAsync(commentCommand.ToComment());
        }
    }
}