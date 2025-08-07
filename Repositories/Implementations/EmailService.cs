using server.Repositories.Interfaces;
using System.Net.Mail;
using System.Reflection;

namespace server.Repositories.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetTemplate(string templateName)
        {
            var resourceName = $"server.Templates.{templateName}";

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    var availableResources = assembly.GetManifestResourceNames();
                    throw new FileNotFoundException(
                        $"Template '{resourceName}' not found. Available resources: {string.Join(", ", availableResources)}"
                    );
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public async Task SendVerificationCodeAsync(string toEmail, string code)
        {
            try
            {
                var template = GetTemplate("VerificationEmail.html")
                    .Replace("{code}", code);

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
                        Body = template,
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

        public async Task SendingPasswordResetEmail(string toEmail, string resetLink)
        {

            try
            {
                var template = GetTemplate("PasswordReset.html")
                .Replace("{resetLink}", resetLink)
                .Replace("{year}", DateTime.Now.Year.ToString());

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
                        Subject = "Password Reset Request",
                        Body = template,
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(toEmail);
                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send password reset email: {ex.Message}");
            }
        }

        public string GenerateRandomCode(int length)
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10).ToString()));
        }
    }
}
