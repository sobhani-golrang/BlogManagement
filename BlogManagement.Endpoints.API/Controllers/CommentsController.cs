using System.Threading.Tasks;
using BlogManagement.Core.ApplicationServices.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentApplicationService _commentApplicationService;

        public CommentsController(CommentApplicationService commentApplicationService)
        {
            _commentApplicationService = commentApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommentCommand postForAdd)
        {
            await _commentApplicationService.Add(postForAdd);
            return Ok();
        }
    }
}