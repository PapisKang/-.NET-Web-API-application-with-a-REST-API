using ExpensesWebAPI.Data;
using ExpensesWebAPI.Models;
using ExpensesWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpensesWebAPI.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId, string sortBy)
        {
            IQueryable<Expense> query = _context.Expenses
            .Where(e => e.UserId == userId)
            .Include(e => e.User);

            if (sortBy.ToLower() == "amount")
            {
                query = query.OrderBy(e => e.Amount);
            }
            else
            {
                query = query.OrderByDescending(e => e.Date);
            }

            return await query.ToListAsync();
        }
    }
}
