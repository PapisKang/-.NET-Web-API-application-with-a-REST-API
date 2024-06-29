using ExpensesWebAPI.Repositories.Interfaces;
using ExpensesWebAPI.Repositories;
using ExpensesWebAPI.Services.Interfaces;
using ExpensesWebAPI.Services;

namespace ExpensesWebAPI
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExpenseService, ExpenseService>();
        }
    }
}
