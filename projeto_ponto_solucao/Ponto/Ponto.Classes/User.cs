namespace Ponto.Classes
{
    public abstract class User
    {
        public string Cpf { get; set; }
        public string Name { get; set; }

        public User(string cpf, string name)
        {
            Cpf = cpf;
            Name = name;
        }
    }
}
