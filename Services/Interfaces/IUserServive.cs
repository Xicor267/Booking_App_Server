using server.DTO;
using server.Models;

namespace server.Services.Interfaces
{
    public interface IUserServive
    {
        Task<IEnumerable<User>> GetUserAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<string> RegisterAsync(RegisterDTO model);
        Task<bool> VerifyCodeAsync(string email, string code);
        Task<User> SignInAsync(SignInDTO model);
        Task RequestPasswordResetAsyncs(string email);
        Task UpdatePasswordAsync(string email, string token, string newPassword);
    }
}
