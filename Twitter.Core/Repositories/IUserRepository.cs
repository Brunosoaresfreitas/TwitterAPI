using Twitter.Core.Entities;

namespace Twitter.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
