using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Lib.DefinedExceptions;

namespace VendingMachine.Lib
{
    public class VendingMachine : IVendingMachine
    {
        private List<Coin> _insertedCoins;

        public VendingMachine(IInventory inventory, IWallet wallet)
        {
            Inventory = inventory;
            Wallet = wallet;
            VendingMachineStatus = VendingMachineStatus.Ready;

            _insertedCoins = new List<Coin>();
        }

        public VendingMachineStatus VendingMachineStatus { get; private set; }
        public IInventory Inventory { get; }
        public IWallet Wallet { get; }

        public List<Coin> Sell(Product product)
        {
            var isValidStatus = VendingMachineStatus == VendingMachineStatus.CollectingCoins;
            if (!isValidStatus)
                throw new InvalidOperationException("invalid operation, please insert coins first");
            if(!Inventory.Contains(product))
                throw new ProductNotFoundException();
            var rest = _insertedCoins.Sum(x => x.Value) - product.Price;
            var isSufficientMoneyInserted = rest >= 0;
            if (!isSufficientMoneyInserted)
                throw new InSufficientMoneyInsertedException();

            var exchange = Wallet.GetCoinsBack(rest);
            Inventory.RemoveProduct(product);
            _insertedCoins.ForEach(c => Wallet.AddCoin(c));
            exchange.ForEach(c => Wallet.RemoveCoin(c));
            VendingMachineStatus = VendingMachineStatus.Ready;
            ClearInsertedCoins();

            return exchange;
        }

        public List<Coin> InsertCoin(Coin coin)
        {
            if (VendingMachineStatus == VendingMachineStatus.CollectingCoins
                || VendingMachineStatus == VendingMachineStatus.Ready)
            {
                _insertedCoins.Add(coin);
                VendingMachineStatus = VendingMachineStatus.CollectingCoins;
                return _insertedCoins;
            }

            throw new InvalidOperationException("invalid operation, please insert coins first");
        }

        public List<Coin> Refund()
        {
            if (VendingMachineStatus == VendingMachineStatus.CollectingCoins
                || VendingMachineStatus == VendingMachineStatus.NotFoundItem)
            {
                var refundValue = _insertedCoins;
                ClearInsertedCoins();
                VendingMachineStatus = VendingMachineStatus.Ready;
                return refundValue;
            }

            throw new InvalidOperationException("invalid operation, can not refund");
        }

        private void ClearInsertedCoins()
        {
            _insertedCoins = new List<Coin>();
        }
    }
}