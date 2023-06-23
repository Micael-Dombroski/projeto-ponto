namespace Ponto.Classes
{
    public class Administrador : Funcionario
    {
        public string ChaveAdministrador { get; set; }//Uma chave de acesso diferenciada
        public Administrador(string cpf, string nome, string sobrenome, Endereco endereco) : base(cpf, nome, sobrenome, endereco)
        {
            Cpf = cpf;
            Name = nome;
            Usuario = $"{Name.ToLower()}";
            Senha = cpf;
        }
    }
}
