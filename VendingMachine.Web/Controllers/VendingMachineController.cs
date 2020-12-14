using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Lib;

namespace VendingMachine.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendingMachineController : ControllerBase
    {
        private readonly IVendingMachine _vendingMachine;

        public VendingMachineController(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _vendingMachine.Inventory.Product.Select(x => x.Key);
            return products;
        }

        [HttpPost]
        public IEnumerable<Coin> AddCoins([FromBody] int coinValue)
        {
            var coin = new Coin(coinValue);
            var coins = _vendingMachine.InsertCoin(coin);
            return coins;
        }

        [HttpPost("refund")]
        public IEnumerable<Coin> Refund()
        {
            var coins = _vendingMachine.Refund();
            return coins;
        }

        [HttpPost("buy")]
        public JsonResult Buy([FromBody] int index)
        {
            var product = _vendingMachine.Inventory.Product.Keys.FirstOrDefault(x => x.Index == index);
            var change = _vendingMachine.Sell(product);
            return new JsonResult(change);
        }
    }
}