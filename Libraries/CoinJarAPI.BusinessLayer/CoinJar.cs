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

        public void AddCoin(ICoin coin)
        {
            if (_CoinJarAPICache.TotalVolume + coin.Volume > Constants.CoinJarAPIMaxVolume)
            {
                throw new InvalidOperationException("Your coin jar is full!");
            }
            _CoinJarAPICache.TotalAmount += coin.Amount;
            _CoinJarAPICache.TotalVolume += coin.Volume;
        }

        public decimal GetTotalAmount()
        {
            return _CoinJarAPICache.TotalAmount;
        }

        public void Reset()
        {
            _CoinJarAPICache.TotalAmount = 0;
            _CoinJarAPICache.TotalVolume = 0;
        }
    }
}
