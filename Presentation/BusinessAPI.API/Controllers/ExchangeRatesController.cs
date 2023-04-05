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




        [HttpGet("GetAllCrossExchange")]
        public async Task<IActionResult> GetAllCrossExchange([FromQuery] GetAllCrossRateQueryRequest getAllCrossRateQueryRequest)
        {
            GetAllCrossRateQueryResponse response = await _mediator.Send(getAllCrossRateQueryRequest);


            return Ok(response);

        }



        [HttpGet("GetAllExchange")]
        public async Task<IActionResult> GetAllExchange([FromQuery] GetAllExchangeRateQueryRequest getAllExchangeRateQueryRequest)
        {
            GetAllExchangeRateQueryResponse response = await _mediator.Send(getAllExchangeRateQueryRequest);


            return Ok(response);

        }



        [HttpGet("GetCrossByCurrency")]
        public async Task<IActionResult> GetAllByCurrenyCrossExchange([FromQuery] GetByCurrencyCrossRateQueryRequest codeCrossRateQueryRequest )
        {
            GetByCurrencyCrossRateQueryResponse response = await _mediator.Send(codeCrossRateQueryRequest);


            return Ok(response);

        }



        [HttpGet("GetExchangeByCurrency")]
        public async Task<IActionResult> GetAllByCurrenyExchange([FromQuery] GetByCurrencyExchangeRateQueryRequest getByCurrencyExchangeRateQueryRequest)
        {
            GetByCurrencyExchangeRateQueryResponse response = await _mediator.Send(getByCurrencyExchangeRateQueryRequest);

            return Ok(response);
        }
    }
}
