using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class UserService : IUserServive
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
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
    }
}
