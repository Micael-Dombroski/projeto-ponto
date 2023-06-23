namespace Ponto.Classes
{
    public class Administrador : Funcionario
    {
        public string ChaveAdministrador { get; set; }//Uma chave de acesso diferenciada
        public Administrador(
            string cpf,
            string nome,
            string registration,
            string password) : base(cpf, nome, registration, password)
        {
        }
    }
}
