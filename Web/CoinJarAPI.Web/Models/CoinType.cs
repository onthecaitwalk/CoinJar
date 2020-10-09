using System.ComponentModel;

namespace CoinJarAPI.Web.Models
{
    public enum CoinType
    {
        [Description("Penny")]
        Penny = 0,

        [Description("Nickel")]
        Nickel = 1,

        [Description("Dime")]
        Dime = 2,

        [Description("Quarter Dollar")]
        Quarter = 3,

        [Description("Half Dollar")]
        Half = 4,
    }
}
