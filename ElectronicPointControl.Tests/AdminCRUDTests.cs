using NUnit.Framework;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.Tests
{
    public class AdminCRUDTests
    {
        AdminCRUD sut;
        Administrator fakeAdmin;
        CPF fakeCPF;

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

            Administrator result = sut.Get(fakeAdmin.Registration);

            Assert.That(result, Is.EqualTo(fakeAdmin));
        }
    }
}
