using System.Collections.Generic;
using VendingMachine.Lib.DefinedExceptions;

namespace VendingMachine.Lib
{
    public class Inventory : IInventory
    {
        public Inventory(Dictionary<Product, int> availableProducts)
        {
            Product = availableProducts;
        }

        public void AddProduct(Product product, int quantity = 1)
        {
            Product.TryAdd(product, 0);
            Product[product] += quantity;
        }

        public bool Contains(Product product)
        {
            if (Product.ContainsKey(product) && Product[product] > 0)
                return true;
            return false;
        }

        public void RemoveProduct(Product product, int quantity = -1)
        {
            if(!Contains(product))
                throw new ProductNotFoundException();
            AddProduct(product, quantity);
        }

        public Dictionary<Product, int> Product { get; }
    }
}