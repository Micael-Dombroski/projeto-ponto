using NUnit.Framework;
using ElectronicPointControl.Library;
using System.IO;
using System.Collections.Generic;

namespace ElectronicPointControl.Tests
{
    public class AdminCRUDTests
    {
        AdminCRUD sut;
        Administrator fakeAdmin;
        CPF fakeCPF;
        string filePath = "/home/natan/www/jp/projeto-ponto/src/ElectronicPointControl.Library/administrators.txt";

        [SetUp]
        public void SetUp()
        {
            fakeCPF = new("111.444.777-35");
            fakeAdmin = new(name: "name", registration: "registration", password: "password", cpf: fakeCPF);
            sut = new();
        }

        [Test]
        public void Add_EnsureIsPercisting()
        {
            sut.Add(fakeAdmin);

            Dictionary<CPF, Administrator> admins = new();
            using (Stream file = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new(file))
                {
                    string[] adminProps = reader.ReadLine().Split(";");
                    Administrator admin = new Administrator(
                        name: adminProps[2],
                        registration: adminProps[1],
                        password: adminProps[0],
                        cpf: fakeCPF);
                    admins.Add(admin.CPF, admin);
                }
            }
            Administrator result = admins.GetValueOrDefault(fakeAdmin.CPF);

            Assert.That(result, Is.SameAs(result));
        }

        [Test]
        public void Get_EnsureReturnsNullIfAdminNotFound()
        {
            Administrator result = sut.Get(registration: "invalidRegistration");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Get_ReturnAdminIfItsFound()
        {
            var actual = sut.Get(fakeAdmin.Registration);
            var expected = fakeAdmin;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
