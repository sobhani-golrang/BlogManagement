using BlogManagement.Core.Domain.Posts;
using System.Collections.Generic;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class PostApplicationService
    {
        private readonly PostRepository _postRepository;

        public PostApplicationService(PostRepository postRepository)
        {
            _postRepository = postRepository;
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

        public Post Get(int postId)
        {
            return _postRepository.Get(postId);
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
