using ExpensesWebAPI.DTOs;
using ExpensesWebAPI.Models;
using ExpensesWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesWebAPI.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] ExpenseDto expenseDto)
        {
            try
            {
                await _expenseService.CreateExpenseAsync(new Expense
                {
                    Amount = expenseDto.Amount,
                    Comment = expenseDto.Comment,
                    Currency = expenseDto.Currency,
                    Date = DateTime.Now,
                    Type = expenseDto.Type,
                    UserId = expenseDto.UserId,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetExpenses(int userId, [FromQuery] string sortBy = "date")
        {
            IEnumerable<Expense> expenses = await _expenseService.GetExpensesByUserAsync(userId, sortBy);

            return Ok(expenses.Select(e => new ExpenseDto
            {
                UserId = e.UserId,
                User = $"{e.User.FirstName} {e.User.LastName}",
                Date = e.Date,
                Type = e.Type,
                Amount = e.Amount,
                Currency = e.Currency,
                Comment = e.Comment
            }));
        }
    }
}
