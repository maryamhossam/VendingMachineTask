using System;

namespace VendingMachine.Lib.DefinedExceptions
{
    public class IllegalCoinInsertedException : Exception
    {
        public IllegalCoinInsertedException(string message= "Coin Not Found") : base(message)
        {
        }
    }
}