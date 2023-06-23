using System;

namespace Ponto.Classes
{
    public class Funcionario : User, IPonto
    {
        protected static int Index = 0;
        public int ID;
        public DateTime[] Registro = new DateTime[2];//Tamanho 2 pq tem horirio de entrada e saida
        private int IndexRegistro = 0;
        public string Tipo;
        //public TimeOnly CargaHoraria = new TimeOnly(8h); rascunhos
        public Funcionario(
            string cpf,
            string name,
            string registration,
            string password) : base(cpf, name, registration, password)
        {
        }
        public bool MarcarPonto()
        {
            int i = IndexRegistro;
            Registro[i] = DateTime.Now;
            if (i == 0)
            {
                Console.WriteLine($"Olá {Name}, tenha um Ótimo Dia, Bom Trabalho!");
            }
            if (i == 1)
            {
                Console.WriteLine($"Tchau {Name}, tenha uma Ótima Noite, Bom Descanso!");
            }
            IndexRegistro++;
            if (IndexRegistro > 1) //Se for maior q 1 significa q já teve 2 registros
            {
                IndexRegistro = 0;
            }
            return true;
        }

    }
}
