using CoinJar.Models;
using CoinJar.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Services
{
    public class CoinJarService : ICoinJar
    {
        private ICoinRepository _coinRepository;
        public CoinJarService(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        #region Add Coin 
        /*
         * Add coin's to the jar
         * returns the list of all the coins inserted 
         */

        public ResponseModel<List<coin>> AddCoin(coin coin)
        {
            if(coin.Volume != 42) return new ResponseModel<List<coin>>(false, "Coin volume must be 42 fluid ounces");
            try
            {
                var coinList = _coinRepository.AddCoin(coin);
                return new ResponseModel<List<coin>>(true, "Coin inserted into jar",coinList);
            }
            catch(Exception ex)
            {
                return new ResponseModel<List<coin>>(false, ex.Message, null);
            }
            
        }

        #endregion

        #region Get Jar Total
        /*
         * Get the coins from the repository and add up the amount 
         * returns the total
         */
        public ResponseModel<string> GetTotalAmount()
        {
            var coinJarList = _coinRepository.GetCoins();
            decimal total = 0;


            if (coinJarList == null) return new ResponseModel<string>(true, "Coin Jar Empty", $"${total}");
            try
            {
                    foreach (var coin in coinJarList)
                    {
                        total += coin.Amount;
                    }

                return new ResponseModel<string>(true, "Coin count done",$"${total}");
            }
            catch (Exception ex)
            {
                return new ResponseModel<string>(false, ex.Message);
            }

        }
        #endregion

        #region Reset Jar
        /*
         * Removes all the coins inserted
         * Returns a message
         */
        public ResponseModel<string> Reset()
        {
            try
            {
                _coinRepository.ClearJar();
                return new ResponseModel<string>(true, "Coin jar has been successfully rested", "$0.00");
            }
            catch (Exception ex)
            {
                return new ResponseModel<string>(false, ex.Message);
            }
        }
        #endregion
    }
}
