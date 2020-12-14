using System.Collections.Generic;
using System.Linq;
using VendingMachine.Lib.DefinedExceptions;

namespace VendingMachine.Lib
{
    public class Wallet : IWallet
    {
        private readonly Dictionary<Coin, int> _coins;

        public Wallet(Dictionary<Coin, int> availableCoins)
        {
            _coins = availableCoins;
        }

        public void AddCoin(Coin coin, int quantity = 1)
        {
            if (!_coins.ContainsKey(coin))
            {
                throw new IllegalCoinInsertedException();
            }
            _coins[coin] += quantity;
        }

        public void RemoveCoin(Coin coin, int quantity = -1)
        {
            AddCoin(coin, quantity);
        }

        public int GetQuantity(Coin coin)
        {
            if (_coins.ContainsKey(coin))
                return _coins[coin];
            return 0;
        }

        public List<Coin> GetCoinsBack(int amount)
        {
            if (amount == 0)
                return new List<Coin>();
            var availableCoins = _coins.Where(c => c.Key.Value <= amount && c.Value > 0)
                .OrderByDescending(c => c.Key.Value);
            List<Coin> coinsToBeReturned;
            int sum;
            var result = LoopThrowAllCoins();
            if (result.Any())
                return result;
            throw new NoExchangeAvailableException();

            List<Coin> LoopThrowAllCoins()
            {
                for (var i = 0; i < availableCoins.Count(); i++)
                {
                    coinsToBeReturned = new List<Coin>();
                    sum = 0;
                    for (var n = i; n < availableCoins.Count(); n++)
                    {
                        TryAddTheSameCoin(n);
                        var isSolutionFound = sum == amount;
                        if (isSolutionFound)
                            return coinsToBeReturned;
                    }
                }

                return new List<Coin>();
            }

            void TryAddTheSameCoin(int i)
            {
                availableCoins.ElementAt(i).Deconstruct(out var coin, out var count);
                while (coin.Value + sum <= amount && count != 0)
                {
                    coinsToBeReturned.Add(coin);
                    sum += coin.Value;
                    count -= 1;
                }
            }
        }
    }
}