using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Services
{
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }

    public partial class coin : ICoin
    {
        public coin(decimal amount = default(decimal), decimal volume = default(decimal))
        {
            // to ensure "Amount" is required (not null)
            if (amount < 1)
            {
                throw new InvalidDataException("Amount is a required property for coin and cannot be null");
            }
            else
            {
                this.Amount = amount;
            }
            // to ensure "volume" is required (not null)
            if (volume < 1)
            {
                throw new InvalidDataException("Volume is a required property for coin and cannot be null");

            }
            else
            {
                this.Volume = volume;
            }
        }
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }
}
