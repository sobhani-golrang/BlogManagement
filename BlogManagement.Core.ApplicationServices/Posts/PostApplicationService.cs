using System;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Core.Domain.PostViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class PostApplicationService
    {
        private readonly PostRepository _postRepository;
        private readonly PostViewRepository _postViewRepository;

        public PostApplicationService(PostRepository postRepository, PostViewRepository postViewRepository)
        {
            _postRepository = postRepository;
            _postViewRepository = postViewRepository;
        }

        public void Add(AddUpdatePostCommand postCommand)
        {
            _postRepository.Add(postCommand.ToPost());
        }

        public void Update(int id, AddUpdatePostCommand postCommand)
        {
            var post = postCommand.ToPost();
            post.Id = id;
            _postRepository.Update(post);
        }

        public async Task<PostViewModel> Get(int postId)
        {
            await _postViewRepository.Add(new PostView { PostId = postId, ViewDate = DateTime.Now });
            var post = _postRepository.Get(postId);
            return new PostViewModel
            {
                Title = post.Title,
                Body = post.Body,
                ViewCount = post.PostViews.Count,
                Comments = post.Comments
            };
        }

        public List<Post> Get()
        {
            return _postRepository.Get();
        }

        public void Remove(int postId)
        {
            _postRepository.Remove(postId);
        }
    }
}
