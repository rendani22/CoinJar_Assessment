using CoinJar.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace CoinJar.Repository
{
    public class CoinRepository : ICoinRepository
    {
        // cache key, where the coin data will be saved
        private string cacheKey = "_coins";
        private ObjectCache cache = MemoryCache.Default;
        CacheItemPolicy policy = new CacheItemPolicy();

        #region Add Coins to cache
        public List<coin> AddCoin(coin coin)
        {
            var coinJar = GetCoins();

            // check if coin jar is null
            if (coinJar == null)
            {
                // add the coin to a list and save the list
                var coinList = new List<coin>();
                coinList.Add(coin);
                cache.Set(cacheKey, coinList, policy);
            }
            else
            {
                // add the coin to a list and save the list
                IList collection = coinJar;
                collection.Add(coin);
                cache.Set(cacheKey, collection, policy);
            }
            //Return the current coin list
            return GetCoins();
        }
        #endregion

        #region Get Coin from cache
        public List<coin> GetCoins()
        {
            // Get the 
            var coinJar = cache.Get(cacheKey);
            return (List<coin>)coinJar;
        }
        #endregion

        #region Clear cache
        public void ClearJar()
        {
            //Remove coin from jar
            cache.Remove(cacheKey);
        }
        #endregion
    }
}
