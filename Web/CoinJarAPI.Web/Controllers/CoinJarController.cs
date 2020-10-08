using System;
using CoinJarAPI.BusinessLayer;
using CoinJarAPI.BusinessLayer.Extensions;
using CoinJarAPI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoinJarAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private readonly ICoinJar _CoinJarAPI;
        public CoinJarController(ICoinJar CoinJarAPI)
        {
            _CoinJarAPI = CoinJarAPI;
        }

        /// <summary>
        /// Gets the total amount contained in the coin jar.
        /// </summary>
        /// <returns>Total amount in coin jar.</returns>
        /// <response code="200">Successfully returned the coin jar total amount.</response>
        [HttpGet("total")]
        public IActionResult GetTotalAmount()
        {
            return Ok(string.Format("{0:C}", _CoinJarAPI.GetTotalAmount()));
        }
        
        /// <summary>
        /// Resets the coin jar by setting total amount and volume to zero.
        /// </summary>
        /// <returns></returns>
        [HttpPut("reset")]
        public IActionResult Reset()
        {
            _CoinJarAPI.Reset();
            return Ok("Your coin jar has been emptied.");
        }

        /// <summary>
        /// Adds a coin to the jar.
        /// </summary>
        /// <param name="coinRequest"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddCoin(AddCoinRequest coinRequest)
        {
            var coin = CastCoinTypeToCoin(coinRequest.CoinType);
            if (coin != null)
            {
                _CoinJarAPI.AddCoin(coin);
                return Ok($"A {coinRequest.CoinType.GetDescription()} was added to your coin jar.");
            }

            return BadRequest("Only US coins are accepted.");
        }

        private Coin CastCoinTypeToCoin(CoinType coinType)
        {
            switch (coinType)
            {
                case CoinType.Penny:
                    return new Penny();
                case CoinType.Nickel:
                    return new Nickel();
                case CoinType.Dime:
                    return new Dime();
                case CoinType.Quarter:
                    return new Quarter();
                case CoinType.Half:
                    return new Half();
                default:
                    return null;
            }
            
        }
    }
}
