using BlogManagement.Core.ApplicationServices.Blogs;
using BlogManagement.Core.Domain.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogApplicaitonService _blogApplicaitonService;

        public BlogsController(BlogApplicaitonService blogApplicaitonService)
        {
            _blogApplicaitonService = blogApplicaitonService;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _blogApplicaitonService.Get();
        }
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return _blogApplicaitonService.Get(id);
        }

        [HttpPost]
        public IActionResult Add(AddBlogCommand blogForAdd)
        {
            _blogApplicaitonService.Add(blogForAdd);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogApplicaitonService.Remove(id);
            return NoContent();
        }
    }
}
