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
            CNPJ sut = new CNPJ("11.222.333/0001-81");

            Assert.That(sut.cnpj, Is.EqualTo("11222333000181"));
        }

        [Test]
        [TestCase("111.111.111/1111-11")]
        [TestCase("777.777.777/7777-77")]
        public void Throw_IfAllNumbersAreEqual(string cnpjValue)
        {
            Assert.Throws<InvalidCNPJException>(
                delegate
                {
                    new CNPJ(cnpjValue);
                }
            );
        }

        [Test]
        [TestCase("1")]
        [TestCase("173648723649827364827461283746")]
        public void Throw_IfLengthIsIncorrect(string cnpjValue)
        {
            Assert.Throws<InvalidCNPJException>(
                        delegate { new CNPJ(cnpjValue); });
        }

        [Test]
        public void Throw_IfVerifyingDigitsAreWrong()
        {
            Assert.Throws<InvalidCNPJException>(
                    delegate { new CNPJ("11.222.333/0001-42"); });
        }
    }
}
