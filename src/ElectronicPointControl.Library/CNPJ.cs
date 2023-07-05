using System;

namespace ElectronicPointControl.Library
{
    public struct CNPJ
    {
        public string Value { get; set; }

        public void DoValidations()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.Substring(0, 2)
                   + "."
                   + Value.Substring(2, 3)
                   + "."
                   + Value.Substring(5, 3)
                   + "/"
                   + Value.Substring(8, 4)
                   + "-"
                   + Value.Substring(12, 2);
        }
    }
}
