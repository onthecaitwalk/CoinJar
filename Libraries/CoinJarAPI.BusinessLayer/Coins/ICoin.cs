using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJarAPI.BusinessLayer
{
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }
}
