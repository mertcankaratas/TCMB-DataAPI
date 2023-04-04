using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Features.Commands.ExchangeCrossRate.CreateExchangeCrossRate;
using DataAPI.Application.Features.Commands.ExchangeEffectiveRate.CreateExchangeEffectiveRate;
using DataAPI.Application.Features.Commands.ExchangeRate.CreateExchangeRate;
using DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate;
using DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetAllExchangeEffectiveRate;
using DataAPI.Application.Features.Queries.ExchangeRate.GetAllExchangeRate;
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

        [HttpPost("exchange")]
        public async Task<IActionResult> WriteAllExchange(CreateExchangeRateCommandRequest createExchangeRateCommandRequest)
        {

            CreateExchangeRateCommandResponse response = await _mediator.Send(createExchangeRateCommandRequest);

            return Ok(response);

        }

        [HttpPost("Crossexchange")]
        public async Task<IActionResult> WriteAllCrossExchange(CreateExchangeCrossRateCommandRequest createExchangeCrossRateCommandRequest )
        {

            CreateExchangeCrossRateCommandResponse response = await _mediator.Send(createExchangeCrossRateCommandRequest);

            return Ok(response);

        }

        [HttpPost("effectiveexchange")]
        public async Task<IActionResult> WriteAllEffectiveExchange(CreateExchangeEffectiveRateCommandRequest createExchangeEffectiveRateCommandRequest)
        {

            CreateExchangeEffectiveRateCommandResponse response = await _mediator.Send(createExchangeEffectiveRateCommandRequest);

            return Ok(response);

        }



        [HttpGet("cross")]
        public async Task<IActionResult> GetAllCrossExchange([FromQuery]GetAllCrossRateQueryRequest getAllCrossRateQueryRequest)
        {
            GetAllCrossRateQueryResponse response = await _mediator.Send(getAllCrossRateQueryRequest);


            return Ok(response);

        }

        [HttpGet("effective")]
        public async Task<IActionResult> GetAllEffectiveExchange([FromQuery] GetAllExchangeEffectiveRateQueryRequest getAllExchangeEffectiveRateQueryRequest )
        {

            GetAllExchangeEffectiveRateQueryResponse response = await _mediator.Send(getAllExchangeEffectiveRateQueryRequest);

            return Ok(response);

        }


        [HttpGet("exchange")]
        public async Task<IActionResult> GetAllExchange([FromQuery] GetAllExchangeRateQueryRequest getAllExchangeRateQueryRequest )
        {
            GetAllExchangeRateQueryResponse response = await _mediator.Send(getAllExchangeRateQueryRequest);
            

            return Ok(response);

        }



    }
}
