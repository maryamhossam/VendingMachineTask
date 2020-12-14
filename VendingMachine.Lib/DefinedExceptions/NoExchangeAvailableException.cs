using System;

namespace VendingMachine.Lib.DefinedExceptions
{
    public class NoExchangeAvailableException : Exception
    {
        public NoExchangeAvailableException(string message = "No Exchange Available") : base(message)
        {
        }
    }
}