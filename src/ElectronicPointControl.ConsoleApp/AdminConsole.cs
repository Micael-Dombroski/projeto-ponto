using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class AdminConsole
    {
        private string menuOption;
        private ConsoleUtils utils;

        public void Execute()
        {
            string optionToBack = "5";

            do
            {
                Console.Clear();
                utils.ShowHeader("Menu Administrador");
                ShowMenu();
                ReadMenuOption();
                HandleMenu();
            } while (menuOption != optionToBack);
        }

        public void NewEmployee()
        {
            utils.ShowHeader("Novo Administrador");
            string registration = utils.ReadRegistration();
            if (utils.EmployeeExists(registration))
                utils.HandleError("Administrador já cadastrado");
            CPF cpf = utils.ReadCPF();
            string name = utils.ReadName();
            string password = utils.ReadPassword();
            WorkLoad workLoad = utils.ReadWorkLoad();
            Employee employee = new Employee(cpf, name, registration, password, workLoad);

            utils.HandleSuccess("Funcionário criado com sucesso");
        }

        private void ShowMenu()
        {
            Console.WriteLine("[1] Cadastrar");
            Console.WriteLine("[2] Editar");
            Console.WriteLine("[3] Excluir");
            Console.WriteLine("[4] Exibir todos os Funcionários");
            Console.WriteLine("[5] Voltar");
        }

        private void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        private void HandleMenu()
        {
            switch (menuOption)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
        }

        internal void NewAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
