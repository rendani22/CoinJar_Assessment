using CoinJar.Services;
using System.Collections.Generic;

namespace CoinJar.Repository
{
    public interface ICoinRepository
    {
        List<coin> AddCoin(coin coin);
        void ClearJar();
        List<coin> GetCoins();
    }
}