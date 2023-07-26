using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class ConsoleUtils
    {
        private EmployeeCRUD employees = new();
        private AdminCRUD adminstrators = new();

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

        public string ReadRegistration()
        {
            Console.Write("Digite a matrícula: ");
            return Console.ReadLine();
        }

        public CPF ReadCPF()
        {
            Console.Write("Digite o CPF: ");
            return new CPF(Console.ReadLine());
        }

        public string ReadName()
        {
            Console.Write("Digite o nome: ");
            return Console.ReadLine();
        }

        public string ReadPassword()
        {
            Console.Write("Digite a senha: ");
            return Console.ReadLine();
        }

        public WorkLoad ReadWorkLoad()
        {
            Console.Write("Digite a hora em que se deve bater o ponto para Iniciar a jornada de trabalho: ");
            var startHour = Convert.ToDateTime(Console.ReadLine());
            string answer;
            Console.WriteLine("Deseja informar o horário de Pausa? S/N");
            answer = Console.ReadLine();
            if (answer.ToLower() == "s")
            {
                Console.Write("Digite a hora em que se deve bater o ponto para Iniciar a Pausa: ");
                var starPause = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Digite a hora em que se deve bater o ponto para Finalizar a Pause: ");
                var finishPause = Convert.ToDateTime(Console.ReadLine());
                Console.Write("A hora em que se deve bater o ponto para Encerrar a jornada de trabalho: ");
                var endHour = Convert.ToDateTime(Console.ReadLine());
                return new WorkLoad(startHour,endHour, starPause, finishPause);
            }
            else
            {
                Console.Write("A hora em que se deve bater o ponto para Encerrar a jornada de trabalho: ");
                var endHour = Convert.ToDateTime(Console.ReadLine());
                return new WorkLoad(startHour, endHour, null, null);
            }
        }
    }
}
