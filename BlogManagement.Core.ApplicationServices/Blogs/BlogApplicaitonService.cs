using BlogManagement.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogManagement.Core.ApplicationServices.Blogs
{
    public class BlogApplicaitonService
    {
        private readonly BlogRepository _blogRepository;

        public BlogApplicaitonService(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void Add(AddBlogCommand blogCommand)
        {
            _blogRepository.Add(blogCommand.ToBlog());
        }

        public Blog Get(int blogId)
        {
            return _blogRepository.Get(blogId);
        }

        public List<Blog> Get()
        {
            return _blogRepository.Get();
        }

        public void Remove(int blogId)
        {
            _blogRepository.Remove(blogId);
        }
    }
}
