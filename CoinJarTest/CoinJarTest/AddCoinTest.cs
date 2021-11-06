using CoinJar.Repository;
using CoinJar.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinJarTest.CoinJarTest
{
    [TestClass]
    public class AddCoinTest
    {
        private readonly CoinJarService _coinJarService;
        private readonly CoinRepository _coinRepository;
        public AddCoinTest()
        {
            _coinRepository = new CoinRepository();
            _coinJarService = new CoinJarService(_coinRepository);
        }

        [TestMethod]
        public void AddCoin_Successfully()
        {
            coin coin = new coin(20,42);
            var result = _coinJarService.AddCoin(coin);
            Assert.IsTrue(result.isSuccessful);
        }

        [TestMethod]
        public void AddCoin_Unsuccessfully()
        {
            coin coin = new coin(2, 40);
            var result = _coinJarService.AddCoin(coin);
            Assert.IsFalse(result.isSuccessful);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException),
    "Amount is a required property for coin and cannot be null")]
        public void AddCoin_Amount_Error()
        {
            coin coin = new coin(0, 42);
            _coinJarService.AddCoin(coin);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidDataException),
"Volume is a required property for coin and cannot be null")]
        public void AddCoin_Volume_Error()
        {
            coin coin = new coin(4, 0);
            _coinJarService.AddCoin(coin);
        }


    }


}
