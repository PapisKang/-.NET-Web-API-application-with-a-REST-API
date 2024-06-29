using ExpensesWebAPI.Data;
using ExpensesWebAPI.Models;
using ExpensesWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpensesWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserAsync(string firstName, string lastName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
