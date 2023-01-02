using Microsoft.EntityFrameworkCore;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);
        }
    }
}
