using CoinJar.Repository;
using CoinJar.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJarTest.CoinJarTest
{
    [TestClass]
    public class GetTotalTest
    {
        private readonly CoinJarService _coinJarService;
        private readonly CoinRepository _coinRepository;
        public GetTotalTest()
        {
            _coinRepository = new CoinRepository();
            _coinJarService = new CoinJarService(_coinRepository);
        }

        [TestMethod]
        public void getTotal_Successfully()
        {
            var coinList = new List<coin>()
            {
                new coin(2,42),
                new coin(1,42),
                new coin(1,42),
                new coin(1,42),
                new coin(1,42),
                new coin(2,42),
                new coin(3,42),
                new coin(5,42),
            };

            foreach(var coin in coinList)
            {
                _coinJarService.AddCoin(coin);
            }

            var result = _coinJarService.GetTotalAmount();
            Assert.IsTrue(result.isSuccessful);
        }

        [TestMethod]
        public void getTotal_EmptyJar_Successfully()
        {
            _coinJarService.Reset();
            var result = _coinJarService.GetTotalAmount();
            Assert.AreEqual(result.Message, "Coin Jar Empty");
        }

    }
}
