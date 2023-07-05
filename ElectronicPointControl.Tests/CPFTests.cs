using NUnit.Framework;
using ElectronicPointControl.Library;

namespace ElectronicPointControl.Tests
{
    public class CPFTests
    {
        [Test]
        public void ThrowInvalidCPFException_IfCpfHasNoSufficentLenght()
        {
            Assert.Throws<InvalidCPFException>(
                    delegate { new CPF("invalid_length_cpf"); },
                    "Número de caracteres é insuficiente.");
        }
    }
}
