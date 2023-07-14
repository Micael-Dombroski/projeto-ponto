namespace ElectronicPointControl.Library
{
    public class Company
    {
        public string Name;
        public CNPJ CNPJ;

        public Company(string name, CNPJ cnpj)
        {
            Name = name;
            CNPJ = cnpj;
        }
    }
}
