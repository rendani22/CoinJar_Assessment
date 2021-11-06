using CoinJar.Models;
using CoinJar.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace CoinJar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinController : ControllerBase
    {
        private ICoinJar _coinJar;

        public CoinController( ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        [HttpPost]
        public ResponseModel<List<coin>> AddCoin(coin coin)
        {
            return _coinJar.AddCoin(coin);
        }

        [HttpGet]
        public ResponseModel<string> coinTotal()
        {
            return _coinJar.GetTotalAmount();
        }

        [HttpDelete]
        public ResponseModel<string> resetJar()
        {
            return _coinJar.Reset();
        }
    }
}
