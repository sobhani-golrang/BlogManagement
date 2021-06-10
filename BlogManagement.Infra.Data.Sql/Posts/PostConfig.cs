using System;
using BlogManagement.Core.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.Posts
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Body).IsRequired().HasMaxLength(500);
            builder.Property(c => c.BlogId).IsRequired();

            builder.Property<DateTime>("InsertDate");
            builder.Property<DateTime>("UpdateDate");
        }
    }
}
