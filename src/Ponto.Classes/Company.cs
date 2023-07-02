namespace Ponto.Classes
{
    public class Company
    {
        public string Nome;
        public CNPJ CNPJ;

        public Company(string nome, CNPJ cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
        }
    }
}
