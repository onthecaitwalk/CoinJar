using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJarAPI.BusinessLayer
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
