using CoinJar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Services
{
    public interface ICoinJar
    {
        ResponseModel<List<coin>> AddCoin(coin coin);
        ResponseModel<string> GetTotalAmount();
        ResponseModel<string> Reset();
    }
}
