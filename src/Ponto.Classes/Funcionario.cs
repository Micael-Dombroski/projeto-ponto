using System;

namespace Ponto.Classes
{
    public class Employee : User
    {
        public DateTime[] Registro = new DateTime[2];//Tamanho 2 pq tem horirio de entrada e saida

        public Employee(
            CPF cpf,
            string name,
            string registration,
            string password) : base(cpf, name, registration, password)
        {
        }

        public void DoPoint()
        {
        }

    }
}
