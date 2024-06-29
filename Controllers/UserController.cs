using ExpensesWebAPI.DTOs;
using ExpensesWebAPI.Models;
using ExpensesWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesWebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                await _userService.CreateUserAsync(new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Currency = userDto.Currency
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // Even if UserDto and User are the same, by principle we convert to Dto
            IEnumerable<UserDto> users = (await _userService.GetUsersAsync()).Select(o => new UserDto
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                Currency = o.Currency
            });

            return Ok(users);
        }
    }
}
