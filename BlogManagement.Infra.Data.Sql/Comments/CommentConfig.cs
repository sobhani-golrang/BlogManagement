using BlogManagement.Core.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.Comments
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Author).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Text).IsRequired().HasMaxLength(500);
        }
    }
}