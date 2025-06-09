using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthApi.Models;
using UserAuthApi.Data;

namespace UserAuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserStore _userStore = new UserStore();

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var users = await _userStore.LoadUsersAsync();

            if (users.Any(u => u.IcNumber == user.IcNumber))
            {
                return BadRequest("User already exists.");
            }

            users.Add(user);
            await _userStore.SaveUsersAsync(users);

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            var users = await _userStore.LoadUsersAsync();

            var user = users.SingleOrDefault(u => u.IcNumber == loginUser.IcNumber && u.HashedPassword == loginUser.HashedPassword);
            if (user == null)
                return Unauthorized("Invalid IC or password");

            return Ok("Login successful");
        }
    }
}
