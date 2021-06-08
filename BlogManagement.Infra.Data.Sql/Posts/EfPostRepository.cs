using BlogManagement.Core.Domain.Posts;
using BlogManagement.Infra.Data.Sql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infra.Data.Sql.Posts
{
    public class EfPostRepository : PostRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfPostRepository(BlogManagementDbContext postManagementDb)
        {
            _blogManagementDb = postManagementDb;
        }
        public void Add(Post post)
        {
            _blogManagementDb.Add(post);
            _blogManagementDb.SaveChanges();
        }

        public Post Get(int postId)
        {
            return _blogManagementDb.Posts.FirstOrDefault(c => c.Id == postId);
        }

        public List<Post> Get()
        {
            return _blogManagementDb.Posts.ToList();
        }

        public void Remove(int postId)
        {
            var post = new Post
            {
                Id = postId
            };
            _blogManagementDb.Posts.Remove(post);
            _blogManagementDb.SaveChanges();
        }
    }
}
