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
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly IEmailService _emailService;
        private readonly IPendingUserRepository _pendingUserRepository;

        public UserService(IUserRepository userRepository, IVerificationCodeRepository verificationCodeRepository, IEmailService emailService, IPendingUserRepository pendingUserRepository)
        {
            _userRepository = userRepository;
            _verificationCodeRepository = verificationCodeRepository;
            _emailService = emailService;
            _pendingUserRepository = pendingUserRepository;
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
            if (!IsValidEmail(model.Email))
            {
                return "Invalid email format";
            }

            if (!IsValidPhoneNumber(model.PhoneNumber))
            {
                return "Invalid phone number format";
            }

            var existingUser = await _userRepository.GetUserAsync();
            if (existingUser.Any(u => u.Email == model.Email))
            {
                return "User already exists";
            }

            var existingPendingUser = await _pendingUserRepository.GetPendingUserByEmailAsync(model.Email);
            if (existingPendingUser != null)
            {
                return "User is pending verification";
            }

            var pendingUser = new PendingUser
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                CreatedAt = DateTime.UtcNow
            };

            var code = _emailService.GenerateRandomCode(6);
            var verificationCode = new VerificationCode
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Code = code,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(10)
            };

            await _pendingUserRepository.AddPendingUserAsync(pendingUser);
            await _verificationCodeRepository.AddVertificationCodeAsync(verificationCode);
            await _pendingUserRepository.SaveAsync();
            await _verificationCodeRepository.SaveAsync();

            await _emailService.SendVerificationCodeAsync(model.Email, code);

            return pendingUser.Id.ToString();
        }

        public async Task<bool> VerifyCodeAsync(string email, string code)
        {
            var verification = await _verificationCodeRepository.GetVerificationCodeAsync(email, code);
            if (verification == null)
            {
                return false;
            }

            var pendingUser = await _pendingUserRepository.GetPendingUserByEmailAsync(email);
            if (pendingUser == null)
            {
                return false;
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = pendingUser.FirstName,
                LastName = pendingUser.LastName,
                Email = pendingUser.Email,
                Address = pendingUser.Address,
                PhoneNumber = pendingUser.PhoneNumber,
                Password = pendingUser.Password,
                CreatedAt = pendingUser.CreatedAt,
            };

            await _userRepository.AddUserAsync(user);
            await _pendingUserRepository.DeletePendingUserAsync(email);
            await _userRepository.SaveAsync();
            await _pendingUserRepository.SaveAsync();

            return true;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+?[1-9]\d{1,14}|[0]\d{9})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
