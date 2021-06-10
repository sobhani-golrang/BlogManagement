using BlogManagement.Core.ApplicationServices.Posts;
using BlogManagement.Core.Domain.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostApplicationService _postApplicationService;

        public PostsController(PostApplicationService postApplicationService)
        {
            _postApplicationService = postApplicationService;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _postApplicationService.Get();
        }
        [HttpGet("{id}")]
        public async Task<PostViewModel> Get(int id)
        {
            return await _postApplicationService.Get(id);
        }

        [HttpPost]
        public IActionResult Add(AddUpdatePostCommand postForAdd)
        {
            _postApplicationService.Add(postForAdd);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AddUpdatePostCommand postForUpdate)
        {
            _postApplicationService.Update(id, postForUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postApplicationService.Remove(id);
            return NoContent();
        }
    }
}
