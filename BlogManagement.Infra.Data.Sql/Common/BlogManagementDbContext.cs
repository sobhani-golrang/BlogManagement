using BlogManagement.Core.Domain.Blogs;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infra.Data.Sql.Common
{
    public class BlogManagementDbContext : DbContext
    {
        public BlogManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
