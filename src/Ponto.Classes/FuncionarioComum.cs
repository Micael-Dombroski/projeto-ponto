namespace Ponto.Classes
{
    public class FuncionarioComum : Funcionario
    {
        public FuncionarioComum(
            string cpf,
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
