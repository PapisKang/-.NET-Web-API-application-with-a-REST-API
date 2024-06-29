using ExpensesWebAPI.Models;

namespace ExpensesWebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserAsync(string firstName, string lastName);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
