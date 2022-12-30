using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>

    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(co => co.Id);
        }
    }
}
