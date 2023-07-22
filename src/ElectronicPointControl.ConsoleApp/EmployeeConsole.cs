using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class EmployeeConsole: UserConsole
    {
        private string menuOption;
        private ConsoleUtils utils = new();
        private Employee logedEmployee;
        private PunchClock punchClock;

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
                    Console.Clear();
                    utils.ShowHeader("Informações do Funcionário");
                    Console.WriteLine($"CPF: {logedEmployee.CPF}");
                    Console.WriteLine($"Nome: {logedEmployee.Name}");
                    Console.WriteLine($"Usuário: {logedEmployee.Registration}");
                    Console.WriteLine($"Senha: {logedEmployee.Password}");
                    Console.WriteLine($"Carga Horária: {logedEmployee.WorkLoad.StartHour.ToString("H:mm:ss")} - {logedEmployee.WorkLoad.EndHour.ToString("H:mm:ss")}\n");
                    PressKeyToBackToMenu();
                    break;
                case "2":
                    Console.Clear();
                    PunchingClock();
                    PressKeyToBackToMenu();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida");
                    PressKeyToBackToMenu();
                    break;
            }

        }

        public void PunchingClock()
        {
            try
            {
                punchClock= new(logedEmployee);
                punchClock.PunchClocked();
                utils.HandleSuccess($"Ponto Batido com sucesso às {DateTime.Now.ToString("H:mm:ss")}");
            }
            catch (System.Exception e)
            {
                utils.HandleError(e.Message);
            }
        }
        private void PressKeyToBackToMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
            Console.ReadLine();
        }
    }
}
