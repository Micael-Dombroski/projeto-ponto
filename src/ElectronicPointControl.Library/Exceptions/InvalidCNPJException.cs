using System;

namespace ElectronicPointControl.Library.Exceptions
{
    public class InvalidCNPJException : Exception
    {
        public InvalidCNPJException(string message) : base(message)
        {
        }
    }
}
