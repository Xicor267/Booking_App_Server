using System.Text;

namespace server.DTO
{
    public class RegisterDTO
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _address;
        private string _phoneNumber;
        private string _password;

        public string FirstName
        {
            get => _firstName; 
            set => _firstName = DecodeBase64(value);
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = DecodeBase64(value);
        }
        public string Email
        {
            get => _email;
            set => _email = DecodeBase64(value);
        }
        public string Address
        {
            get => _address; 
            set => _address = DecodeBase64(value);
        }
        public string PhoneNumber
        {
            get => _phoneNumber; 
            set => _phoneNumber = DecodeBase64(value);
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
