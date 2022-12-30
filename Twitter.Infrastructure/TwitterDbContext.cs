using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Twitter.Core.Entities;

namespace Twitter.Infrastructure
{
    public class TwitterDbContext : DbContext
    {
        public TwitterDbContext(DbContextOptions<TwitterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
