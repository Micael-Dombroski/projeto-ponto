using System;

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

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   Registration == administrator.Registration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Registration);
        }

        public override string ToString()
        {
            return $"{CPF};{Name};{Registration};{Password}";
        }

    }
}
