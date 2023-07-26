using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class EmployeeConsole
    {
        private string menuOption;
        static EmployeeCRUD crud = new();
        static Employee loggedEmployee;
        private PunchClock punchClock;
        static ConsoleUtils utils = new();

        public void RegisterEmployee()
        {
            try
            {
                Console.Write("Digite o nome do número do CPF: ");
                var cpf = new CPF(Console.ReadLine());

                Console.Write("Digite o nome do funcionário: ");
                string name = Console.ReadLine();

                Console.Write("Digite a matrícula: ");
                string registration = Console.ReadLine();

                Console.Write("Digite a senha para acessar o sistema: ");
                string password = Console.ReadLine();

                Console.Write("Digite a hora de INÍCIO do espediente: ");
                var hourToStart = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Digite a hora do FIM do espediente: ");
                var hourToEnd = Convert.ToDateTime(Console.ReadLine());

                WorkLoad workLoad = new(hourToStart, hourToEnd);

                var employee = new Employee(cpf, name, registration, password, workLoad);

                crud.Add(employee);
            }
            catch (Exception e)
            {
                utils.HandleError(e.Message);
            }
        }

        public void DoLogin()
        {
            utils.ShowHeader("login funcionário");

            Console.Write("Matrícula: ");
            string registration = Console.ReadLine();

            Console.Write("Senha: ");
            string password = Console.ReadLine();

            var employee = crud.Get(registration);

            if (employee is null)
            {
                utils.HandleError("Funcionário não encontrado!");
                return;
            }

            if (employee.PasswordIsCorrect(password))
            {
                loggedEmployee = employee;
                Console.WriteLine(loggedEmployee.Name);
                EmployeeMenu();
            }
            else
            {
                utils.HandleError("Senha incorreta");
            }
        }

        public void EmployeeMenu()
        {
            while (true)
            {
                Console.Clear();
                utils.ShowHeader("menu do funcionário");
                Console.WriteLine($"Logado como: {loggedEmployee.Name}");
                ShowMenu();
                ReadMenuOption();
                HandleEmployeeMenu();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("[1] Bater ponto");
            Console.WriteLine("[2] Redefinir senha");
            Console.WriteLine("[0] Voltar");
        }

        public void HandleEmployeeMenu()
        {
            Console.Clear();
            switch (menuOption)
            {
                case "1":
                    PunchingClock();
                    break;
                case "2":
                    EditPassword();
                    break;
                case "0":
                    BackToMainMenu();
                    break;
                default: 
                    utils.HandleError("Opção inválida");
                    break;
            }
            BackToMenu();
        }

        private void EditPassword()
        {
            utils.ShowHeader("Atualizar senha");

            Console.Write("Digite a nova senha: ");
            string password = Console.ReadLine();

            Console.Write("Repita a senha: ");
            string passwordConfirmation = Console.ReadLine();

            if (password != passwordConfirmation)
            {
                utils.HandleError("Senha não confere!");
                return;
            }

            loggedEmployee.SetPassword(password);
            crud.Update(loggedEmployee);
            utils.HandleSuccess("Senha atualizada!");
        }

        public void PunchingClock()
        {
            try
            {
                 punchClock = new(loggedEmployee);
                 punchClock.PunchClocked();
                 utils.HandleSuccess($"\nPonto Batido com sucesso às {DateTime.Now.ToString("H:mm:ss")}");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("");
                utils.HandleError(e.Message);
            }
        }

        private void BackToMainMenu()
        {
            Program.MainMenu();
        }

        void BackToMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para prosseguir...");
            Console.ReadKey();
        }

        void ReadMenuOption()
        {
            Console.Write("=> ");
            menuOption = Console.ReadLine();
        }


    }
}
