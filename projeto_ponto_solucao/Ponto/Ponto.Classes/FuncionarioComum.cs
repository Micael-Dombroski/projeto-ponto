namespace Ponto.Classes
{
    public class FuncionarioComum : Funcionario
    {
        public FuncionarioComum(
            string cpf,
            string nome,
            string sobrenome,
            Endereco endereco) : base(cpf, nome, sobrenome, endereco)
        {
            Cpf = cpf;
            Name = nome;
            Usuario = $"{Name.ToLower()}";
            Senha = cpf;
        }
    }
}
