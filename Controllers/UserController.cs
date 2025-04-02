using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServive _userServive;

        public UserController(IUserServive userServive)
        {
            _userServive = userServive;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _userServive.GetUserAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            if (User == null) return NotFound();

            var user = await _userServive.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null) return BadRequest();

            await _userServive.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (user == null || id != user.Id) return BadRequest();

            var existingUser = await _userServive.GetUserByIdAsync(id);
            if (existingUser == null) return BadRequest();

            await _userServive.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userServive.GetUserByIdAsync(id);

            if (user == null) return NotFound();

            await _userServive.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
