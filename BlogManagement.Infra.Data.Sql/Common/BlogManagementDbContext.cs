using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Core.Domain.PostViews;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infra.Data.Sql.Common
{
    public class BlogManagementDbContext : DbContext
    {
        public BlogManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostView> PostViews { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
