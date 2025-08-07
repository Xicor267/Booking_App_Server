namespace server.Repositories.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationCodeAsync(string email, string code);
        string GenerateRandomCode(int length);
        Task SendingPasswordResetEmail(string email, string resetLink);
    }
}
