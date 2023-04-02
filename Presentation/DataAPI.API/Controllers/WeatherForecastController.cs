using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using DataAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("getallexchange")]
        public async Task<IActionResult> GetAllExchange()
        {

            List<ExchangeRateItem> data = await TCMBExchangeRateService.GetExchangData("USD");

            return Ok(data);

        }


        [HttpGet("getallexchangeeffective")]
        public async Task<IActionResult> GetAllExchangeEffective()
        {

            List<ExchangeEffectiveRateItem> data = await TCMBExchangeRateService.GetExchangEffectiveData("USD");

            return Ok(data);

        }



        [HttpGet("getallexchangecross")]
        public async Task<IActionResult> GetAllExchangeCross()
        {

            List<ExchangeCrossRateItem> data = await TCMBExchangeRateService.GetExchangCrossData("USD");

            return Ok(data);

        }
    }
}