using ExpensesWebAPI.Data;
using ExpensesWebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ExpensesWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseContextDB")));

            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureServices();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpensesAPI", Version = "v1" });
            });

            var app = builder.Build();

            app.CreateDbIfNotExists();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
