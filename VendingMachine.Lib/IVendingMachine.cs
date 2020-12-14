using System.Collections.Generic;

namespace VendingMachine.Lib
{
    public interface IVendingMachine
    {
        IInventory Inventory { get; }
        IWallet Wallet { get; }
        List<Coin> InsertCoin(Coin coin);
        List<Coin> Refund();
        List<Coin> Sell(Product product);
    }
}