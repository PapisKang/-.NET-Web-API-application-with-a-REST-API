using ExpensesWebAPI.Models;

namespace ExpensesWebAPI.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense expense);
        Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId, string sortBy);
    }
}
