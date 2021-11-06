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
    public class ResetJarTest
    {
        private readonly CoinJarService _coinJarService;
        private readonly CoinRepository _coinRepository;
        public ResetJarTest()
        {
            _coinRepository = new CoinRepository();
            _coinJarService = new CoinJarService(_coinRepository);
        }

        [TestMethod]
        public void ClearJar_Successfully()
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

            foreach (var coin in coinList)
            {
                _coinJarService.AddCoin(coin);
            }
            var resetResult = _coinJarService.Reset();
            var result = _coinRepository.GetCoins();
            Assert.IsNull(result);
            Assert.IsTrue(resetResult.isSuccessful);
        }
    }
}
