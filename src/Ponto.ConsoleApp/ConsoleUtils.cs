using System;

namespace Ponto.ConsoleApp
{
    public class ConsoleUtils
    {
        private void EmployeeCRUD employees = new ();

        public void ShowHeader(string header) => Console.WriteLine($"==== {header.ToUpper()} ====");
        
        public void HandleError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void HandleSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    
        public bool EmployeeExists(string registration) => employees.Get(registration) is not null;

        private string ReadRegistration()
        {
            Console.Write("Digite a matrícula: ");
            return Console.ReadLine();
        }

        private void ReadCPF()
        {
            Console.Write("Digite o CPF: ");
            return Console.ReadLine();
        }

        private string ReadName()
        {
            Console.Write("Digite o nome: ");
            return Console.ReadLine();
        }

        private string ReadPassword()
        {
            Console.Write("Digite a senha: ");
            return Console.ReadLine();
        }
    }
}
