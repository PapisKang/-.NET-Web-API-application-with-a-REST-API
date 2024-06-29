using ExpensesWebAPI.Models;

namespace ExpensesWebAPI.Services.Interfaces
{
    public interface IExpenseService
    {
        Task CreateExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId, string sortBy);
    }
}
