using System;

namespace ElectronicPointControl.Library
{
    public class Administrator
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Administrator(
            string login,
            string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public bool PasswordIsCorrect(string password)
        {
            return Password == password;
        }

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   Login == administrator.Login;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Login);
        }

        public override string ToString()
        {
            return $"{Login};{Password}";
        }
    }
}
