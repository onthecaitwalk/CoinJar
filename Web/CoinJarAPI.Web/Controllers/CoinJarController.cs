using CoinJarAPI.BusinessLayer;
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
        /// <param name="coin"></param>
        /// <returns></returns>
        [HttpPost("add/{coin}")]
        public IActionResult AddCoin(string coin)
        {
            if (coin == "1")
            {
                _CoinJarAPI.AddCoin(new Penny());
                return Ok($"{nameof(Penny)} was added to your coin jar.");
            }

            return BadRequest("Only US coins are accepted.");
        }

    }
}
