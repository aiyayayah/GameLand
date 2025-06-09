using Microsoft.AspNetCore.Mvc;
using UserAuthApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserAuthApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory user storage (for demo only!)
        private static List<User> users = new List<User>();

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (users.Any(u => u.IcNumber == user.IcNumber))
            {
                return BadRequest("User already exists.");
            }

            users.Add(user);
            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            var user = users.SingleOrDefault(u => u.IcNumber == loginUser.IcNumber && u.HashedPassword == loginUser.HashedPassword);
            if (user == null)
                return Unauthorized("Invalid IC or password");

            return Ok("Login successful");
        }
    }
}
