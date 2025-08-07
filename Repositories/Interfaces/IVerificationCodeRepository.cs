using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IVerificationCodeRepository
    {
        Task AddVertificationCodeAsync(VerificationCode code);
        Task<VerificationCode> GetVerificationCodeAsync(string email, string code);
        Task DeleteVerificationCodeAsync(Guid id);
        Task SaveAsync();
    }
}
