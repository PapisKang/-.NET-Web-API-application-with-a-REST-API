using ExpensesWebAPI.Models;

namespace ExpensesWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<User> GetUserAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
