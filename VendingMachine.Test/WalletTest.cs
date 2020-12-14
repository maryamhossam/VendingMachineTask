using System;
using System.Collections.Generic;
using VendingMachine.Lib;
using Xunit;

namespace VendingMachine.Test
{
    public class WalletTest
    {
        private readonly Dictionary<Coin, int> Coins = new Dictionary<Coin, int>()
        {
           { new Coin(100), 1},
           { new Coin(50), 2},
           { new Coin(20), 3},
           { new Coin(10), 4}
        };

        [Theory()]
        [InlineData(100,1)]
        [InlineData(150, 2)]
        [InlineData(70, 2)]
        [InlineData(60, 2)]
        public void Expect_Smallest_Coins_Count(int amount, int count)
        {
            var wallet = new Wallet(Coins);
            var exchange = wallet.GetCoinsBack(amount);
            var expectedCount = exchange.Count;
            Assert.Equal(count, expectedCount);
        }
    }
}
