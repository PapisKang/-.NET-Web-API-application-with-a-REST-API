using ExpensesWebAPI.Models;
using ExpensesWebAPI.Repositories.Interfaces;
using ExpensesWebAPI.Services.Interfaces;

namespace ExpensesWebAPI.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            await ValidateExpense(expense);
            await _expenseRepository.CreateExpenseAsync(expense);
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId, string sortBy)
        {
            return await _expenseRepository.GetExpensesByUserAsync(userId, sortBy);
        }

        private async Task ValidateExpense(Expense expense)
        {
            // Validate the Type property
            if (!Enum.TryParse(expense.Type, true, out ExpenseType _))
            {
                throw new InvalidOperationException("Possible expense type values: Restaurant, Hotel, and Misc");
            }

            // An expense cannot have a date in the future,
            if (expense.Date > DateTime.Now)
            {
                throw new InvalidOperationException("Expense date cannot be in the future");
            }

            // An expense cannot be dated more than 3 months ago
            if (expense.Date < DateTime.Now.AddMonths(-3))
            {
                throw new InvalidOperationException("Expense date cannot be more than 3 months ago");
            }

            // The comment is mandatory
            if (string.IsNullOrEmpty(expense.Comment))
            {
                throw new InvalidOperationException("Comment is mandatory");
            }

            User user = await _userRepository.GetUserAsync(expense.UserId);

            if (user == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            // The currency of the expense must match the user’s currency.
            if (user.Currency != expense.Currency)
            {
                throw new InvalidOperationException("Expense currency must match user's currency");
            }

            // A user cannot declare the same expense twice (same date and amount)
            IEnumerable<Expense> existingExpenses = await _expenseRepository.GetExpensesByUserAsync(expense.UserId, "date");
            if (existingExpenses.Any(e => e.Date.Date == expense.Date.Date && e.Amount == expense.Amount))
            {
                throw new InvalidOperationException("Duplicated expense");
            }
        }
    }
}
