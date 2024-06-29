using ExpensesWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
