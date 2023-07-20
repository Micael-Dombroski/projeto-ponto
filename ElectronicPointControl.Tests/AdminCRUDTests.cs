using NUnit.Framework;
using ElectronicPointControl.Library;
using System.IO;

namespace ElectronicPointControl.Tests
{
    public class AdminCRUDTests
    {
        AdminCRUD sut;
        Administrator fakeAdmin;
        CPF fakeCPF;
        string filePath = "/home/natan/www/jp/projeto-ponto/ElectronicPointControl.Tests/fakeAdministrators.txt";

        [SetUp]
        public void SetUp()
        {
            fakeCPF = new("111.444.777-35");
            fakeAdmin = new(login: "root", password: "root");
            sut = new(filePath: filePath);
        }

        [TearDown]
        public void TearDown()
        {
            File.WriteAllText(filePath, string.Empty);
        }

        [Test]
        public void Add_EnsureIsPercisting()
        {
            sut.Add(fakeAdmin);

            using (Stream file = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new(file))
                {
                    string[] adminProps = reader.ReadLine().Split(";");
                    Administrator admin = new Administrator(adminProps[0], adminProps[1]);
                    Assert.That(admin, Is.EqualTo(fakeAdmin));
                }
            }
        }

        [Test]
        public void Get_EnsureReturnsNullIfAdminNotFound()
        {
            Administrator result = sut.Get();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Get_ReturnAdminIfItsFound()
        {
            sut.Add(fakeAdmin);

            var actual = sut.Get();
            var expected = fakeAdmin;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Delete_EnsureDeleteTheAdmin()
        {
            sut.Add(fakeAdmin);
            sut.Delete();
            var result = sut.Get();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Update_EnsureIfAdminExistsItWasUpdated()
        {
            sut.Add(fakeAdmin);
            fakeAdmin.Login = "newLogin";
            sut.Update(fakeAdmin);

            var result = sut.Get();

            Assert.That(result.Login, Is.EqualTo("newLogin"));
        }
    }
}
