using System;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class AdminConsole
    {
        // private string menuOption;
        // private string EditAnswer;
        // private Administrator logedAdministrator;
        // private ConsoleUtils utils= new();
        // private EmployeeCRUD employees = new();
        // private string registration;

        // public void SetLogedAdministrator(Administrator administrator)
        // {
        //     logedAdministrator = administrator;
        //     Execute();
        // }

        // public void Execute()
        // {
        //     string optionToBack = "6";

        //     do
        //     {
        //         Console.Clear();
        //         utils.ShowHeader("Menu Administrador");
        //         ShowMenu();
        //         ReadMenuOption();
        //         HandleMenu();
        //     } while (menuOption != optionToBack);
        // }

        // public void NewEmployee()
        // {
        //     utils.ShowHeader("Novo Funcionário");
        //     string registration = utils.ReadRegistration();
        //     if (utils.EmployeeExists(registration))
        //         utils.HandleError("Funcionário já cadastrado");
        //     CPF cpf = utils.ReadCPF();
        //     string name = utils.ReadName();
        //     string password = utils.ReadPassword();
        //     WorkLoad workLoad = utils.ReadWorkLoad();
        //     Employee employee = new Employee(cpf, name, password: password, registration: registration, workLoad: workLoad);
        //     employees = new EmployeeCRUD();
        //     employees.Add(employee);

        //     utils.HandleSuccess("Funcionário criado com sucesso");
        // }
        // public void DeleteEmployee()
        // {
        //     utils.ShowHeader("Deletar Funcionário");
        //     string registration = utils.ReadRegistration();
        //     if (utils.EmployeeExists(registration))
        //     {
        //         employees.Delete(registration);
        //         utils.HandleSuccess("Funcionário deletado com sucesso");
        //     }
        //     else
        //         utils.HandleError("Funcionário não encontrado");
        // }

        // public void EditEmployee()
        // {
        //     string registration = utils.ReadRegistration();
        //     if (utils.EmployeeExists(registration))
        //     {
        //         Employee editEmployee = employees.Get(registration);
        //         string name = editEmployee.Name;
        //         string  password = editEmployee.Password;
        //         WorkLoad workload = editEmployee.WorkLoad;
        //         Console.WriteLine("Deseja Editar o Nome do Funcionário? S/N");
        //         ReadEditeAnswer();
        //         if (EditAnswer == "s")
        //         {
        //             name = utils.ReadName();
        //         }
        //         Console.WriteLine("Deseja Editar a Senha do Funcionário? S/N");
        //         ReadEditeAnswer();
        //         if (EditAnswer == "s")
        //         {
        //             password = utils.ReadPassword();
        //         }
        //         Console.WriteLine("Deseja Editar a Carga Horária do Funcionário? S/N");
        //         ReadEditeAnswer();
        //         if (EditAnswer == "s")
        //         {
        //             workload = utils.ReadWorkLoad();
        //         }
        //         Employee editedEmployee = new Employee(editEmployee.CPF, name, editEmployee.Registration, password, workload);
        //         employees.Update(editedEmployee);
        //         utils.HandleSuccess("Funcionário Editado com Sucesso");
        //     }
        //     else
        //         utils.HandleError("Funcionário Não Encontrado");
        // }

        // private void ShowMenu()
        // {
        //     Console.WriteLine("[1] Cadastrar");
        //     Console.WriteLine("[2] Editar");
        //     Console.WriteLine("[3] Excluir");
        //     Console.WriteLine("[4] Exibir as Informações de um Funcionário");
        //     Console.WriteLine("[5] Exibir todos os Funcionários");
        //     Console.WriteLine("[6] Voltar");
        // }

        // private void ReadMenuOption()
        // {
        //     Console.Write("=> ");
        //     menuOption = Console.ReadLine();
        // }

        // private void HandleMenu()
        // {
        //     switch (menuOption)
        //     {
        //         case "1":
        //             Console.Clear();
        //             NewEmployee();
        //             PressKeyToBackToMenu();
        //             break;
        //         case "2":
        //             Console.Clear();
        //             EditEmployee();
        //             PressKeyToBackToMenu();
        //             break;
        //         case "3":
        //             Console.Clear();
        //             DeleteEmployee();
        //             PressKeyToBackToMenu();
        //             break;
        //         case "4":
        //             Console.Clear();
        //             Console.WriteLine("Informe o Nome de Usuário do Funcionário que deseja ver as informações: ");
        //             ReadRegistration();
        //             if (utils.EmployeeExists(registration))
        //             {
        //                 utils.HandleError("Funcionário Não Encontrado");
        //             }
        //             else
        //             {
        //                 Employee employee = employees.Get(registration);
        //                 Console.Clear();
        //                 utils.ShowHeader("Informações do Funcionário");
        //                 Console.WriteLine($"CPF: {employee.CPF}");
        //                 Console.WriteLine($"Nome: {employee.Name}");
        //                 Console.WriteLine($"Usuário: {employee.Registration}");
        //                 Console.WriteLine($"Senha: {employee.Password}");
        //                 Console.WriteLine($"Carga Horária: {employee.WorkLoad.StartHour.ToString("H:mm:ss")} - {employee.WorkLoad.EndHour.ToString("H:mm:ss")}\n");
        //             }
        //             PressKeyToBackToMenu();
        //             break;
        //         case "5":
        //             Console.Clear();
        //             Console.WriteLine("Lista de Funcionarios");
        //             Console.WriteLine("CPF | Nome | Usuário | Senha | Carga Horária");
        //             foreach (var item in employees.GetAll())
        //             {
        //                 Console.WriteLine($"{item.CPF} | {item.Name} | {item.Registration} | {item.Password} | {item.WorkLoad.StartHour.ToString("H:mm:ss")} - {item.WorkLoad.EndHour.ToString("H:mm:ss")}");
        //             }
        //             PressKeyToBackToMenu();
        //             break;
        //         case "6":
        //             Console.Clear();
        //             Console.WriteLine("Voltando...");
        //             break;
        //         default:
        //             Console.Clear();
        //             Console.WriteLine("Opção Inválida");
        //             PressKeyToBackToMenu();
        //             break;
        //     }
        // }
        // private void PressKeyToBackToMenu()
        // {
        //     Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
        //     Console.ReadLine();
        // }

        // private void ReadEditeAnswer()
        // {
        //     Console.Write("=> ");
        //     EditAnswer = Console.ReadLine().ToLower();
        // }
        // private void ReadRegistration()
        // {
        //     Console.Write("=> ");
        //     registration = Console.ReadLine();
        // }
    }
}
