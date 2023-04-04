using DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate;
using DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetAllExchangeEffectiveRate;
using DataAPI.Application.Features.Queries.ExchangeRate.GetAllExchangeRate;
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
    }
}
