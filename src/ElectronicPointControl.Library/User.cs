namespace Ponto.Classes
{
    public abstract class User
    {
        public CPF CPF { get; set; }
        public string Name { get; set; }
        public string Registration { get; protected set; }
        public string Password { get; protected set; }

        public User(CPF cpf, string name, string registration, string password)
        {
            CPF = cpf;
            Name = name;
            Registration = registration;
            Password = password;
        }

        public bool PasswordIsCorrect(string password)
        {
            return Password == password;
        }
    }
}
