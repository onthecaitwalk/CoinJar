using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJarAPI.Web.Models
{
    public enum CoinType
    {
        [Description("")]
        None = 0,

        [Description("Penny")]
        Penny = 1,

        [Description("Nickel")]
        Nickel = 2,

        [Description("Dime")]
        Dime = 3,

        [Description("Quarter Dollar")]
        Quarter = 4,

        [Description("Half Dollar")]
        Half = 5,
    }
}
