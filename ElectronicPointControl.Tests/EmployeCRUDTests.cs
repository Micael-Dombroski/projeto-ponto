using NUnit.Framework;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.Tests
{
    public class EmployeCRUDTests
    {
        AdminCRUD sut;
        string filePath = "/home/natan/www/jp/projeto-ponto/ElectronicPointControl.Tests/fakeEmployees.txt";

        [SetUp]
        public void SetUp()
        {
            sut = new(filePath);
        }
    }
}
