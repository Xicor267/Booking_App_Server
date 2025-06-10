using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IVerificationCodeRepository
    {
        Task AddVertificationCodeAsync(VerificationCode code);
        Task<VerificationCode> GetVerificationCodeAsync(string email, string code);
        Task SaveAsync();
    }
}
