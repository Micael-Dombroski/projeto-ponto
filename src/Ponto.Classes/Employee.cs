namespace Ponto.Classes
{
    public class Employee : User
    {
        public Employee(
            CPF cpf,
            string name,
            string registration,
            string password) : base(cpf, name, registration, password)
        {
        }

        public void DoPoint()
        {
        }

    }
}
