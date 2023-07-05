using System;
using System.Collections.Generic;
using System.Linq;

namespace Ponto.Classes
{
    public class EmployeeCRUD
    {
        private Dictionary<String, Employee> employees = new();

        public void Add(Employee employee) => employees.Add(employee.Registration, employee);

        public List<Employee> GetAll() => employees.Values.ToList();

        public Employee Get(string registration) => employees.GetValueOrDefault(registration);

        public void Update(Employee employee)
        {
            Delete(employee.Registration);
            Add(employee);
        }

        public void Delete(string registration) => employees.Remove(registration);
    }
}
