using Microsoft.EntityFrameworkCore;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Infrastructure.Persistence.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterDbContext _dbContext;

        public TweetRepository(TwitterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tweet>> GetAllAsync()
        {
            return await _dbContext.Tweets.ToListAsync();
        }

        public async Task<Tweet> GetByIdAsync(int id)
        {
            return await _dbContext
                .Tweets
                .Include(t => t.Comments)
                .SingleOrDefaultAsync(t => t.Id == id);
                
        }

        public async Task CreateTweetAsync(Tweet tweet)
        {
            await _dbContext.Tweets.AddAsync(tweet);
        }


        public async Task DeleteTweetAsync(Tweet tweet)
        {
            _dbContext.Remove(tweet);
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
