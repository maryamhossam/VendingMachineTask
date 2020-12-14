using System;

namespace VendingMachine.Lib.DefinedExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message= "Product Not Found") : base(message)
        {
        }
    }
}