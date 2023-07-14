using NUnit.Framework;
using ElectronicPointControl.Library;
using System;
using System.Collections.Generic;
using System.IO;

namespace ElectronicPointControl.Tests
{
    public class EmployeCRUDTests
    {
        EmployeeCRUD sut;
        string filePath = "/home/natan/www/jp/projeto-ponto/ElectronicPointControl.Tests/fakeEmployees.txt";
        Employee fakeEmployee;
        CPF fakeCPF;
        WorkLoad fakeWorkload;

        [SetUp]
        public void SetUp()
        {
            fakeCPF = new CPF("111.444.777-35");
            fakeWorkload = new WorkLoad
            {
                StartHour = new DateTime(),
                EndHour = new DateTime()
            };
            fakeEmployee = new Employee(
                workLoad: fakeWorkload,
                cpf: fakeCPF,
                name: "name",
                registration: "registration",
                password: "password");
            sut = new EmployeeCRUD(filePath);
        }

        [TearDown]
        public void TearDown()
        {
            File.WriteAllText(filePath, string.Empty);
        }

        [Test]
        public void Add_EnsureItsSaving()
        {
            sut.Add(fakeEmployee);

            List<Employee> employees = new();
            using (Stream file = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new(file))
                {
                    var employeeProps = reader.ReadLine().Split(";");
                    Employee employee = new(
                        new CPF(employeeProps[0]),
                        employeeProps[1],
                        employeeProps[2],
                        employeeProps[3],
                        new WorkLoad()
                        {
                            StartHour = Convert.ToDateTime(employeeProps[4]),
                            EndHour = Convert.ToDateTime(employeeProps[5])
                        });
                    employees.Add(employee);
                }
            }
            var result = employees.Find(employee => employee.Registration == fakeEmployee.Registration);

            Assert.That(result, Is.EqualTo(fakeEmployee));
        }

        [Test]
        public void Get_EnsureReturnsNullIfAdminNotFound()
        {
            var result = sut.Get(registration: "invalidRegistration");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetAll_ReturnAnObjetcOfTypeList()
        {
            var actual = sut.GetAll();

            Assert.That(actual, Is.TypeOf<List<Employee>>());
        }

        [Test]
        public void GetAll_ReturnsCorrectsObjects()
        {
            sut.Add(fakeEmployee);
            sut.Add(fakeEmployee);

            var result = sut.GetAll();

            Assert.That(result[0], Is.EqualTo(fakeEmployee));
            Assert.That(result[1], Is.EqualTo(fakeEmployee));
        }

        [Test]
        public void Get_ReturnAdminIfItsFound()
        {
            sut.Add(fakeEmployee);

            var actual = sut.Get(fakeEmployee.Registration);
            var expected = fakeEmployee;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Delete_EnsureDeleteTheAdmin()
        {
            sut.Add(fakeEmployee);
            sut.Delete(fakeEmployee.Registration);
            var result = sut.Get(fakeEmployee.Registration);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Update_EnsureIfAdminExistsItWasUpdated()
        {
            sut.Add(fakeEmployee);
            fakeEmployee.Name = "newName";
            sut.Update(fakeEmployee);

            var result = sut.Get(fakeEmployee.Registration);

            Assert.That(result.Name, Is.EqualTo("newName"));
        }
    }
}
