using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
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

            List<ExchangeRateItem> data = await _exchangeRateService.GetExchangData("BGN");

            return Ok(data);

        }

    }
}
