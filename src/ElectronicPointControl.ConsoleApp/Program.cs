using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    class Program
    {
        static string menuOption;
        static EmployeeConsole employeeConsole = new();
        static CompanyConsole companyConsole = new();
        static AdminConsole adminConsole = new();

        static ConsoleUtils utils = new();

        static EmployeeCRUD employees = new();
        static AdminCRUD administrators = new();

        static void Main(string[] args)
        {
            while (true)
            {
                //UpdateEmployeesList();
                //UpdateAdminsList();
                Console.Clear();
                utils.ShowHeader("Menu");
                ShowMainMenu();
                ReadMenuOption();
                HandleMenu();
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("[1] Fazer Login");
            Console.WriteLine("[2] Sobre");
            Console.WriteLine("[0] Sair");
        }

        private static void HandleMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    DoLogin(); break;
                case "2":
                    AboutUs(); break;
                case "0":
                    Exit(); break;
                default: break;
            }
            BackToMainMenu();
        }

        private static void DoLogin()
        {
            utils.ShowHeader("login");

            Console.Write("Digite sua matrícula: ");
            string registration = Console.ReadLine();

            Employee employee = employees.Get(registration);
            Administrator administrator = administrators.Get(registration);
            int typeUser = 0;
            if (employee is null)
            {
                if (administrator is null)
                {
                    utils.HandleError("Usuário não encontrado");
                    return;
                }
                else
                {
                    typeUser = 2;
                }
            }
            else
            {
                typeUser = 1;
            }

            Console.Write("Digite sua senha: ");
            string password = Console.ReadLine();
            if (typeUser == 1)
            {
                if (employee.PasswordIsCorrect(password))
                {
                    typeUser = 1;
                    utils.HandleSuccess("Acesso concedido");

                    employeeConsole.SetLogedEmployee(employee);
                }
                else
                {
                    utils.HandleError("Senha incorreta");
                }
            }
            else if (typeUser == 2)
            {
                if (administrator.PasswordIsCorrect(password))
                {
                    typeUser = 2;
                    utils.HandleSuccess("Acesso concedido");

                    adminConsole.SetLogedAdministrator(administrator);
                }                              
                else
                {
                    utils.HandleError("Senha incorreta");
                }
            }  
        }
        private static void NewCompany()
        {
            companyConsole.NewCompany();
        }

        private static void AboutUs()
        {
            throw new NotImplementedException();
        }

        private static void Exit()
        {
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(1);
        }

        static void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }

        static void BackToMainMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }
        /*
        static void UpdateEmployeesList()
        {
            foreach (var item in adminConsole.SendEmployees())
            {
                if (employees.Get(item.Registration) is null)
                {
                    employees.Add(item);
                }
            }
        }
        static void UpdateAdminsList()
        {
            foreach (var item in adminConsole.SendAdmins())
            {
                if (administrators.Get(item.Registration) is null)
                {
                    administrators.Add(item);
                }
            }
        }*/
    }
}
