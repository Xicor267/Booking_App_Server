namespace server.Repositories.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationCodeAsync(string email, string code);
        string GenerateRandomCode(int length);
    }
}
