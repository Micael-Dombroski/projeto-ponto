using NUnit.Framework;
using ElectronicPointControl.Library.Exceptions;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.Tests
{
    public class CNPJTests
    {
        [Test]
        public void OnCreate_RemoveHyphensDotsAndSlash()
        {
            CNPJ sut = new CNPJ("12.345.678/0009-01");

            Assert.That(sut.cnpj, Is.EqualTo("12345678000901"));
        }
    }
}
