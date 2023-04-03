using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Features.Commands.ExchangeRate.CreateExchangeRate;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        //readonly ITCMBExchangeRateService _exchangeRateService;
        readonly IMediator _mediator;

        public ExchangeRatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllExchange(CreateExchangeRateCommandRequest createExchangeRateCommandRequest)
        {

            CreateExchangeRateCommandResponse response = await _mediator.Send(createExchangeRateCommandRequest);

            return Ok(response);

        }

        //[HttpGet("getallexchange")]
        //public async Task<IActionResult> GetAllExchange()
        //{

        //    List<ExchangeRateItem> data = await _exchangeRateService.GetExchangeData(Application.Enums.Exchange.ExchangeCurrencyType.BGN);

        //    return Ok(data);

        //}


        //[HttpGet("getallexchangeeffective")]
        //public async Task<IActionResult> GetAllExchangeEffective()
        //{

        //    List<ExchangeEffectiveRateItem> data = await _exchangeRateService.GetExchangeEffectiveData(Application.Enums.Exchange.ExchangeEffectiveCurrencyType.USD);

        //    return Ok(data);

        //}

        //[HttpGet("getallexchangecross")]
        //public async Task<IActionResult> GetAllExchangeCross()
        //{

        //    List<ExchangeCrossRateItem> data = await _exchangeRateService.GetExchangeCrossData(Application.Enums.Exchange.ExchangeCrossCurrencyType.USDToAUD);

        //    return Ok(data);

        //}

    }
}
