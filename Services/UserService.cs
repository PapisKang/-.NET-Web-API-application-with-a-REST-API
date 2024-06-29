using ExpensesWebAPI.Models;
using ExpensesWebAPI.Repositories.Interfaces;
using ExpensesWebAPI.Services.Interfaces;

namespace ExpensesWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            await ValidateUser(user);
            await _userRepository.CreateUserAsync(user);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        private async Task ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new InvalidOperationException("FirstName is mandatory");
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new InvalidOperationException("LastName is mandatory");
            }

            if (string.IsNullOrEmpty(user.Currency))
            {
                throw new InvalidOperationException("Currency is mandatory");
            }

            User existingUser = await _userRepository.GetUserAsync(user.FirstName, user.LastName);

            if (existingUser != null)
            {
                throw new InvalidOperationException("This user already exists");
            }
        }
    }
}
