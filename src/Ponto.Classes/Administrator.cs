namespace Ponto.Classes
{
    public class Administrator : Employee
    {
        public Administrator(
            CPF cpf,
            string name,
            string registration,
            string password) : base(cpf, name, registration, password)
        {
        }
    }
}
