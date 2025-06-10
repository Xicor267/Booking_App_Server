using server.Repositories.Interfaces;
using System.Net.Mail;

namespace server.Repositories.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendVerificationCodeAsync(string toEmail, string code)
        {
            try
            {
                var fromEmail = _configuration["EmailSettings:FromEmail"];
                var appPassword = _configuration["EmailSettings:AppPassword"];
                var smtpServer = "smtp.gmail.com";
                var smtpPort = 587;

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.Credentials = new System.Net.NetworkCredential(fromEmail, appPassword);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(fromEmail, "Hotel Booking"),
                        Subject = "Your Verification Code",
                        Body = $"<h3>Your Verification Code</h3><p>Your code is: <strong>{code}</strong></p><p>This code expires in 10 minutes.</p>",
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(toEmail);
                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}");
            }
        }

        public string GenerateRandomCode(int length)
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10).ToString()));
        }
    }
}
