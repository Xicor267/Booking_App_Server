using System.Drawing.Imaging;
using System.Text;

namespace server.DTO
{
    public class SignInDTO
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set => _email = DecodeBase64(value);
        }
        public string Password
        {
            get => _password;
            set => _password = DecodeBase64(value);
        }

        private string DecodeBase64(string encodedValue)
        {
            try
            {
                if (string.IsNullOrEmpty(encodedValue))
                    return encodedValue;

                var bytes = Convert.FromBase64String(encodedValue);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return encodedValue;
            }
        }
    }
}