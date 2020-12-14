using System;

namespace VendingMachine.Lib.DefinedExceptions
{
    public class InSufficientMoneyInsertedException : Exception
    {
        public InSufficientMoneyInsertedException(string message = "not sufficient money inserted") : base(message)
        {
        }
    }
}