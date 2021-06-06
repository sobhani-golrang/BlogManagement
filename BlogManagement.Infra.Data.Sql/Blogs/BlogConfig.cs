using BlogManagement.Core.Domain.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.Blogs
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.EnName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Desciption).IsRequired().HasMaxLength(500);
        }
    }
}
