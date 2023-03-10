using Microsoft.EntityFrameworkCore;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;

namespace Twitter.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private TwitterDbContext _dbContext;

        public UserRepository(TwitterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}
