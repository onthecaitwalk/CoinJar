using System;
using System.ComponentModel.DataAnnotations;
using CoinJarAPI.BusinessLayer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoinJarAPI.Web.Models
{
    public class CoinRequest
    {
        [Required]
        public CoinType CoinType { get; set; }

        internal void Validate(ModelStateDictionary modelState)
        {
            if (!Enum.IsDefined(typeof(CoinType), CoinType))
            {
                modelState.AddModelError(nameof(CoinType), "Only US coins are accepted.");
            }
        }

        internal Coin CastToCoin() =>
            CoinType switch
            {
                CoinType.Penny => new Penny(),
                CoinType.Nickel => new Nickel(),
                CoinType.Dime => new Dime(),
                CoinType.Quarter => new Quarter(),
                CoinType.Half => new Half(),
                _ => throw new ArgumentException("Invalid coin type."),
            };
    }
}
