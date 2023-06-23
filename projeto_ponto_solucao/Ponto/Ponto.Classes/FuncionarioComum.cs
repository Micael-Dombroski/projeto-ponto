namespace Ponto.Classes
{
    public class FuncionarioComum : Funcionario
    {
        public FuncionarioComum(
            string cpf,
            string nome,
            string sobrenome) : base(cpf, nome, sobrenome)
        {
            Usuario = $"{nome.ToLower()}";
            Senha = cpf;
        }
    }
}
