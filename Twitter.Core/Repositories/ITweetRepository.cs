using Twitter.Core.Entities;

namespace Twitter.Core.Repositories
{
    public interface ITweetRepository
    {
        Task<List<Tweet>> GetAllAsync();
        Task<Tweet> GetByIdAsync(int id);
        Task CreateTweetAsync(Tweet tweet);
        Task DeleteTweetAsync(Tweet tweet);
        Task SaveChangesAsync();
    }
}
