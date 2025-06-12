using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.Models;
using server.Services.Implementations;
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
            var user = await _userServive.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null) return BadRequest();

            await _userServive.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string result = await _userServive.RegisterAsync(model);
            if (result == "Invalid email format" || result == "Invalid phone number format" || result == "User already exists" || result == "User is pending verification")
            {
                return BadRequest(new { Message = result });
            }

            return Ok(new { Message = "Registration successful, please verify your email.", PendingUserId = result });
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isValid = await _userServive.VerifyCodeAsync(model.Email, model.Code);
            if (!isValid)
            {
                return BadRequest(new { Message = "Invalid or expired verification code." });
            }

            return Ok(new { Message = "Verification successful, user account activated." });
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] SignInDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userServive.SignInAsync(model);
                return Ok(new
                {
                    Message = "Sign in successful",
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while signing in.", Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (user == null || id != user.UserId) return BadRequest();

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
