using DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate;
using DataAPI.Application.Features.Queries.ExchangeCrossRate.GetByCurrencyCrossRate;
using DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetAllExchangeEffectiveRate;
using DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetByCurrencyExchangeEffectiveRate;
using DataAPI.Application.Features.Queries.ExchangeRate.GetAllExchangeRate;
using DataAPI.Application.Features.Queries.ExchangeRate.GetByCurrencyExchangeRate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ExchangeRatesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet("cross")]
        public async Task<IActionResult> GetAllCrossExchange([FromQuery] GetAllCrossRateQueryRequest getAllCrossRateQueryRequest)
        {
            GetAllCrossRateQueryResponse response = await _mediator.Send(getAllCrossRateQueryRequest);


            return Ok(response);

        }

        [HttpGet("effective")]
        public async Task<IActionResult> GetAllEffectiveExchange([FromQuery] GetAllExchangeEffectiveRateQueryRequest getAllExchangeEffectiveRateQueryRequest)
        {

            GetAllExchangeEffectiveRateQueryResponse response = await _mediator.Send(getAllExchangeEffectiveRateQueryRequest);

            return Ok(response);

        }


        [HttpGet("exchange")]
        public async Task<IActionResult> GetAllExchange([FromQuery] GetAllExchangeRateQueryRequest getAllExchangeRateQueryRequest)
        {
            GetAllExchangeRateQueryResponse response = await _mediator.Send(getAllExchangeRateQueryRequest);


            return Ok(response);

        }



        [HttpGet("crossbycurrency")]
        public async Task<IActionResult> GetAllByCurrenyCrossExchange([FromQuery] GetByCurrencyCrossRateQueryRequest codeCrossRateQueryRequest )
        {
            GetByCurrencyCrossRateQueryResponse response = await _mediator.Send(codeCrossRateQueryRequest);


            return Ok(response);

        }

        [HttpGet("effectivebycurrency")]
        public async Task<IActionResult> GetAllByCurrenyEffectiveExchange([FromQuery] GetByCurrencyExchangeEffectiveRateQueryRequest byCurrencyExchangeEffectiveRateQueryRequest )
        {

            GetByCurrencyExchangeEffectiveRateQueryResponse response = await _mediator.Send(byCurrencyExchangeEffectiveRateQueryRequest);

            return Ok(response);

        }


        [HttpGet("exchangebycurrency")]
        public async Task<IActionResult> GetAllByCurrenyExchange([FromQuery] GetByCurrencyExchangeRateQueryRequest getByCurrencyExchangeRateQueryRequest)
        {
            GetByCurrencyExchangeRateQueryResponse response = await _mediator.Send(getByCurrencyExchangeRateQueryRequest);

            return Ok(response);
        }
    }
}
