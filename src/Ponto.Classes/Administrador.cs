namespace Ponto.Classes
{
    public class Administrador : Employee
    {
        public string ChaveAdministrador { get; set; }//Uma chave de acesso diferenciada

        public Administrador(
            CPF cpf,
            string nome,
            string registration,
            string password) : base(cpf, nome, registration, password)
        {
        }
    }
}
