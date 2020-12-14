using System.Collections.Generic;

namespace VendingMachine.Lib
{
    public interface IInventory
    {
        Dictionary<Product, int> Product { get; }
        void AddProduct(Product product, int quantity = 1);
        bool Contains(Product product);
        void RemoveProduct(Product product, int quantity = -1);
    }
}