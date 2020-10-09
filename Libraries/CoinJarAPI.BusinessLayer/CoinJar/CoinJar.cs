using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CoinJarAPI.UnitTests")]
namespace CoinJarAPI.BusinessLayer
{
    public class CoinJar : ICoinJar
    {
        private readonly CoinJarCache _CoinJarAPICache;

        public CoinJar(CoinJarCache CoinJarAPICache)
        {
            _CoinJarAPICache = CoinJarAPICache;
        }

        /// <summary>
        /// Adds a coin to the coin jar.
        /// </summary>
        /// <param name="coin"></param>
        public void AddCoin(ICoin coin)
        {
            if (_CoinJarAPICache.TotalVolume + coin.Volume > Constants.CoinJarMaxVolume)
            {
                throw new InvalidOperationException("Your coin jar is full!");
            }

            _CoinJarAPICache.TotalAmount += coin.Amount;
            _CoinJarAPICache.TotalVolume += coin.Volume;
        }

        /// <summary>
        /// Gets the total amount in the coin jar. This value will reset when the application starts.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalAmount()
        {
            return _CoinJarAPICache.TotalAmount;
        }

        /// <summary>
        /// Sets the coin jar total amount and volume to zero.
        /// </summary>
        public void Reset()
        {
            _CoinJarAPICache.TotalAmount = 0;
            _CoinJarAPICache.TotalVolume = 0;
        }
    }
}
