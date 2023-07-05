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

        [TestCase("111.111.111-11")]
        [TestCase("333.333.333-33")]
        [TestCase("999.999.999-99")]
        public void Trow_IfAllDigitsAreEqual(string cpfValue)
        {
            Assert.Throws<InvalidCPFException>(
                delegate { new CPF(cpfValue); },
                "CPF não pode ter todos os dígitos iguais");
        }

        public void ThrowInvalidCPFException_WhenCPFIsInvalid()
        {
            Assert.Throws<InvalidCPFException>(
                delegate { new CPF("129.998.001-05"); },
                "CPF inválido");
        }
    }
}
