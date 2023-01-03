using Twitter.Core.Entities;

namespace Twitter.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task CreateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
