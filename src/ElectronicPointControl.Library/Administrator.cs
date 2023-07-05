namespace ElectronicPointControl.Library
{
    public class Administrator : User
    {
        public Administrator(
            CPF cpf,
            string name,
            string registration,
            string password) : base(cpf, name, registration, password)
        {
        }
    }
}
