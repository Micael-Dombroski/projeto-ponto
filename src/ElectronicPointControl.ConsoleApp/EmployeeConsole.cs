using ElectronicPointControl.Library;

namespace ElectronicPointControl.ConsoleApp
{
    public class EmployeeConsole
    {
        private ConsoleUtils utils = new ConsoleUtils();
        private Employee logedEmployee;

        public void SetLogedEmployee(Employee employee)
        {
            logedEmployee = employee;
        }

        public void NewEmployee()
        {
            utils.ShowHeader("Novo Funcionário");
            string registration = utils.ReadRegistration();
            if (utils.EmployeeExists(registration))
                utils.HandleError("Funcionário já cadastrado");
            CPF cpf = utils.ReadCPF();
            string name = utils.ReadName();
            string password = utils.ReadPassword();
            WorkLoad workLoad = utils.ReadWorkLoad();
            Employee employee = new Employee(cpf, name, password: password, registration: registration, workLoad: workLoad);

            utils.HandleSuccess("Funcionário criado com sucesso");
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
