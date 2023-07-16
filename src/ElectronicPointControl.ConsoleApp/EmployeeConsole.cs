using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class EmployeeConsole: UserConsole
    {
        private string menuOption;
        private ConsoleUtils utils = new();
        private Employee logedEmployee;

        public void SetLogedEmployee(Employee employee)
        {
            logedEmployee = employee;
            Execute();
        }

        public void Execute()
        {
            string optionToBack = "3";

            do
            {
                Console.Clear();
                utils.ShowHeader("Menu Funcionário");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            } while (menuOption != optionToBack);
        }

        private void ShowMenu()
        {
            Console.WriteLine("[1] Exibir Informações");
            Console.WriteLine("[2] Bater Ponto");
            Console.WriteLine("[3] Voltar");
        }

        private void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        protected override void HandleMenu()
        {
            switch (menuOption)
            {
                case "1":
                    Console.WriteLine("Informações do Funcionário");
                    Console.WriteLine($"CPF: {logedEmployee.CPF}");
                    Console.WriteLine($"Nome: {logedEmployee.Name}");
                    Console.WriteLine($"Usuário: {logedEmployee.Registration}");
                    Console.WriteLine($"Senha: {logedEmployee.Password}");
                    Console.WriteLine($"Carga Horária: {logedEmployee.WorkLoad.StartHour.ToString("hh:mm:ss")} - {logedEmployee.WorkLoad.EndHour.ToString("hh:mm:ss")}\n");
                    Console.WriteLine("\nPressione qualquer para voltar para o Menu");
                    Console.ReadLine();
                    break;
                case "2":
                    PunchClock();
                    Console.WriteLine("\nPressione qualquer para voltar para o Menu");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

        public void PunchClock()
        {
            try
            {
                logedEmployee.PunchClock();
            }
            catch (System.Exception e)
            {
                utils.HandleError(e.Message);
            }
        }
    }
}
