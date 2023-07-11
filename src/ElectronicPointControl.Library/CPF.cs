using System;

namespace ElectronicPointControl.Library
{
    public class CPF
    {
        private int cpfLengthWithOnlyNumbers = 11;

        public string cpf { get; private set; }

        public CPF(string value)
        {
            cpf = value;
            RemoveDotsAndHyphens();
            DoValidations();
        }

        private void RemoveDotsAndHyphens()
        {
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        }

        public void DoValidations()
        {
            LengthIsCorrect();
            AllDigitsAreEqual();
            ValidateCheckDigits();
        }

        private void LengthIsCorrect()
        {
            if (cpf.Length != cpfLengthWithOnlyNumbers)
                throw new InvalidCPFException("Número de caracteres é insuficiente.");
        }

        private void AllDigitsAreEqual()
        {
            bool allAreEqual = true;

            foreach (char digit in cpf)
                if (digit != cpf[0])
                {
                    allAreEqual = false;
                    break;
                }

            if (allAreEqual)
                throw new InvalidCPFException("CPF não pode ter todos os dígitos iguais");
        }

        private void ValidateCheckDigits()
        {
            CheckFirstVerifyingDigit();
            CheckSecondVerifyingDigit();
        }

        private void CheckFirstVerifyingDigit()
        {
            int[] multipliers = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (int)char.GetNumericValue(cpf[i]) * multipliers[i];

            var rest = sum % 11;
            var expectedDigit =
                (rest < 2 ? 0 : 11 - rest).ToString();

            if (expectedDigit != cpf[9].ToString())
                throw new
                    InvalidCPFException($"CPF inválido");
        }

        private void CheckSecondVerifyingDigit()
        {
            int[] multipliers = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (int)char.GetNumericValue(cpf[i]) * multipliers[i];

            int rest = sum % 11;
            string expectedDigit =
                (rest < 2 ? 0 : 11 - rest).ToString();

            if (expectedDigit != cpf[10].ToString())
                throw new InvalidCPFException("CPF inválido");
        }

        public override string ToString()
        {
            return cpf.Substring(0, 3)
                   + "."
                   + cpf.Substring(3, 3)
                   + "."
                   + cpf.Substring(6, 3)
                   + "-"
                   + cpf.Substring(9, 2);
        }
    }
}
