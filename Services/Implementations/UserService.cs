using server.DTO;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;
using System.Text.RegularExpressions;

namespace server.Services.Implementations
{
    public class UserService : IUserServive
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _userRepository.GetUserAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            if (user.UserId == Guid.Empty)
            {
                user.UserId = Guid.NewGuid();
            }

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
            await _userRepository.SaveAsync();
        }

        public async Task<string> RegisterAsync(RegisterDTO model)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                CreatedAt = DateTime.UtcNow,
                Bookings = new List<Booking?>()
            };

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();

            return user.UserId.ToString();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+?[1-9]\d{1,14}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
