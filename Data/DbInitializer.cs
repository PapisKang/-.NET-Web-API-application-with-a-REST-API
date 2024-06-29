using ExpensesWebAPI.Models;

namespace ExpensesWebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.Users.Any() && context.Expenses.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { FirstName = "Anthony", LastName = "Stark", Currency = "USD" },
                new User { FirstName = "Natasha", LastName = "Romanova", Currency = "RUB" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
