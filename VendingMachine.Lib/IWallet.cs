using System.Collections.Generic;

namespace VendingMachine.Lib
{
    public interface IWallet
    {
        void AddCoin(Coin coin, int quantity = 1);
        int GetQuantity(Coin coin);
        void RemoveCoin(Coin coin, int quantity = -1);
        List<Coin> GetCoinsBack(int amount);
    }
}