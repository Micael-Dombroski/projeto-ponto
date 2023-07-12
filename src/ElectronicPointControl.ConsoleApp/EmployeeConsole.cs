using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class EmployeeConsole: UserConsole
    {
        private ConsoleUtils utils = new ConsoleUtils();
        private Employee logedEmployee;

        public void SetLogedEmployee(Employee employee)
        {
            logedEmployee = employee;
            Execute();
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
                    Console.WriteLine($"Carga Horária: {logedEmployee.WorkLoad.StartHour} - {logedEmployee.WorkLoad.EndHour}\n");
                    break;
                case "2":
                    PunchClock();
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
