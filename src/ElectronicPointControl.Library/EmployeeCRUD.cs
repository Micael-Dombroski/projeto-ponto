using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ElectronicPointControl.Library
{
    public class EmployeeCRUD
    {
        private string filePath;

        private Dictionary<String, Employee> employees = new();

        public EmployeeCRUD(string filePath
                = "/home/natan/www/jp/projeto-ponto/src/ElectronicPointControl.Library/employees.txt")
        {
            this.filePath = filePath;
        }

        public void Add(Employee employee)
        {
            if (!File.Exists(filePath))
            {
                Stream file = File.Open(filePath, FileMode.Create);
                file.Close();
            }
            using (Stream file = File.Open(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new(file))
                {
                    writer.WriteLine(employee);
                }
            }

        }

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
