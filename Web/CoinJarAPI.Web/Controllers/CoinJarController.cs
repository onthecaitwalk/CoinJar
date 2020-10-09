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
        /// <remarks>
        ///  Sample request:
        ///
        ///     GET /api/coinjar/total
        ///
        /// </remarks>
        /// <returns>Total $ amount in coin jar.</returns>
        /// <response code="200">Successfully returned the coin jar total amount.</response>
        /// <response code="500">Coin jar total amount is not available.</response>
        [HttpGet("total")]
        public IActionResult GetTotalAmount()
        {
            return Ok(string.Format("{0:C}", _CoinJarAPI.GetTotalAmount()));
        }

        /// <summary>
        /// Gets all valid coin types.
        /// </summary>
        /// <remarks>
        ///  Sample request:
        ///
        ///     GET /api/coinjar/coin/types
        ///
        /// </remarks>
        /// <returns>All valid coin types.</returns>
        /// <response code="200">Successfully returned the all valid coin types.</response>
        /// <response code="500">Coin types are not available.</response>
        [HttpGet("coin/types")]
        public IActionResult GetCoinType()
        {
            return Ok(CoinTypeResponse.CastCoinTypeResponses());
        }

        /// <summary>
        /// Resets the coin jar by setting total amount and volume to zero.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/coinjar/reset
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Successfully reset the coin jar.</response>
        /// <response code="500">Coin jar reset is not available.</response>
        [HttpPut("reset")]
        public IActionResult Reset()
        {
            _CoinJarAPI.Reset();
            return Ok("Your coin jar has been emptied.");
        }

        /// <summary>
        /// Adds a coin to the jar.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/coinjar/coin
        ///     {
        ///         "coinType": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="coinRequest"></param>
        /// <returns></returns>
        /// <response code="200">Successfully added the coin to the coin jar.</response>
        /// <response code="400">Invalid coin type.</response>
        /// <response code="500">Adding to the coin jar is not available.</response>
        [HttpPost("coin")]
        public IActionResult AddCoin(CoinRequest coinRequest)
        {
            coinRequest.Validate(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);               
            }

            var coin = CoinRequest.CastToCoin(coinRequest);
            _CoinJarAPI.AddCoin(coin);
            return Ok($"A {coinRequest.CoinType.GetDescription()} was added to your coin jar.");
        }        
    }
}
