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
            var templateEmail = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Hotel Booking Verification</title>\r\n</head>\r\n<body style=\"margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #f5f5f5;\">\r\n    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\" style=\"background-color: #f5f5f5; padding: 20px 0;\">\r\n        <tr>\r\n            <td align=\"center\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\" style=\"max-width: 600px; background-color: #ffffff; border-radius: 12px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); overflow: hidden;\">\r\n                    \r\n                    <!-- Header với gradient -->\r\n                    <tr>\r\n                        <td style=\"background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 40px 30px; text-align: center;\">\r\n                            <h1 style=\"color: #ffffff; font-size: 28px; margin: 0; font-weight: 300; letter-spacing: 1px;\">\r\n                                🏨 Hotel Booking\r\n                            </h1>\r\n                            <p style=\"color: #e8ecff; font-size: 16px; margin: 10px 0 0 0; opacity: 0.9;\">\r\n                                Premium Booking Experience\r\n                            </p>\r\n                        </td>\r\n                    </tr>\r\n                    \r\n                    <!-- Main Content -->\r\n                    <tr>\r\n                        <td style=\"padding: 50px 40px;\">\r\n                            <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">\r\n                                <tr>\r\n                                    <td style=\"text-align: center; padding-bottom: 30px;\">\r\n                                        <h2 style=\"color: #333333; font-size: 24px; margin: 0; font-weight: 600;\">\r\n                                            Verification Code\r\n                                        </h2>\r\n                                        <p style=\"color: #666666; font-size: 16px; margin: 15px 0 0 0; line-height: 1.5;\">\r\n                                            We've received a request to verify your hotel booking. Please use the code below to complete your reservation.\r\n                                        </p>\r\n                                    </td>\r\n                                </tr>\r\n                                \r\n                                <!-- Verification Code Box -->\r\n                                <tr>\r\n                                    <td style=\"text-align: center; padding: 30px 0;\">\r\n                                        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"margin: 0 auto; background: linear-gradient(135deg, #ff9a9e 0%, #fecfef 50%, #fecfef 100%); border-radius: 12px; padding: 3px;\">\r\n                                            <tr>\r\n                                                <td style=\"background-color: #ffffff; border-radius: 10px; padding: 25px 40px; text-align: center;\">\r\n                                                    <span style=\"font-size: 32px; font-weight: bold; color: #667eea; letter-spacing: 3px; font-family: 'Courier New', monospace;\">\r\n                                                        {code}\r\n                                                    </span>\r\n                                                </td>\r\n                                            </tr>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                                \r\n                                <!-- Timer Warning -->\r\n                                <tr>\r\n                                    <td style=\"text-align: center; padding: 20px 0;\">\r\n                                        <div style=\"background-color: #fff3cd; border: 1px solid #ffeaa7; border-radius: 8px; padding: 15px; display: inline-block;\">\r\n                                            <p style=\"color: #856404; font-size: 14px; margin: 0; font-weight: 500;\">\r\n                                                ⏰ This code expires in <strong>10 minutes</strong>\r\n                                            </p>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n                                \r\n                                <!-- Additional Info -->\r\n                                <tr>\r\n                                    <td style=\"padding-top: 30px;\">\r\n                                        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">\r\n                                            <tr>\r\n                                                <td style=\"background-color: #f8f9ff; border-radius: 8px; padding: 20px;\">\r\n                                                    <h3 style=\"color: #333333; font-size: 16px; margin: 0 0 10px 0; font-weight: 600;\">\r\n                                                        📋 What's Next?\r\n                                                    </h3>\r\n                                                    <ul style=\"color: #666666; font-size: 14px; line-height: 1.6; margin: 0; padding-left: 20px;\">\r\n                                                        <li>Enter this code on the verification page</li>\r\n                                                        <li>Complete your booking details</li>\r\n                                                        <li>Receive your confirmation email</li>\r\n                                                    </ul>\r\n                                                </td>\r\n                                            </tr>\r\n                                        </table>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                    \r\n                    <!-- Footer -->\r\n                    <tr>\r\n                        <td style=\"background-color: #f8f9fa; padding: 30px; text-align: center; border-top: 1px solid #e9ecef;\">\r\n                            <p style=\"color: #6c757d; font-size: 14px; margin: 0 0 10px 0;\">\r\n                                Need help? Contact our support team\r\n                            </p>\r\n                            <p style=\"color: #6c757d; font-size: 12px; margin: 0;\">\r\n                                📧 support@hotelluxury.com | 📞 +84 123 456 789\r\n                            </p>\r\n                            <div style=\"margin-top: 20px; padding-top: 20px; border-top: 1px solid #dee2e6;\">\r\n                                <p style=\"color: #adb5bd; font-size: 11px; margin: 0;\">\r\n                                    © 2025 Hotel Luxury. All rights reserved.<br>\r\n                                    This is an automated message, please do not reply to this email.\r\n                                </p>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
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
                        Body = templateEmail,
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
