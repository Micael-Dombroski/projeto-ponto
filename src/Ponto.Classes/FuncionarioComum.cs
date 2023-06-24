namespace Ponto.Classes
{
    public class FuncionarioComum : Employee
    {
        public FuncionarioComum(
            CPF cpf,
            string nome,
            string registration,
            string password)
            : base(
                cpf: cpf,
                name: nome,
                registration: registration,
                password: password)
        {
        }
    }
}
