using BlogManagement.Core.Domain.PostViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.PostViews
{
    public class PostViewConfig : IEntityTypeConfiguration<PostView>
    {
        public void Configure(EntityTypeBuilder<PostView> builder)
        {
            builder.Property(c => c.PostId).IsRequired();
            builder.Property(c => c.ViewDate).IsRequired();
        }
    }
}