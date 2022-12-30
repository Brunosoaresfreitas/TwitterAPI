using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure.Persistence.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder
                .HasKey(tw => tw.Id);

            builder
                .HasMany(co => co.Comments)
                .WithOne()
                .HasForeignKey(co => co.IdTweet)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
