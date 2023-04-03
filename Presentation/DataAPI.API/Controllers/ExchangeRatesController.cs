using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        readonly ITCMBExchangeRateService _exchangeRateService;

        public ExchangeRatesController(ITCMBExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("getallexchange")]
        public async Task<IActionResult> GetAllExchange()
        {

            List<ExchangeRateItem> data = await _exchangeRateService.GetExchangeData("BGN");

            return Ok(data);

        }


        [HttpGet("getallexchangeeffective")]
        public async Task<IActionResult> GetAllExchangeEffective()
        {

            List<ExchangeEffectiveRateItem> data = await _exchangeRateService.GetExchangeEffectiveData("USD");

            return Ok(data);

        }

        [HttpGet("getallexchangecross")]
        public async Task<IActionResult> GetAllExchangeCross()
        {

            List<ExchangeCrossRateItem> data = await _exchangeRateService.GetExchangeCrossData("USDToAUD");

            return Ok(data);

        }

    }
}
