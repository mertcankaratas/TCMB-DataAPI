using DataAPI.Application.Abstraction.Services.ExchangeEffectiveRateWrite;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Commands.ExchangeEffectiveRate.CreateExchangeEffectiveRate
{
    public class CreateExchangeEffectiveRateCommandHandler : IRequestHandler<CreateExchangeEffectiveRateCommandRequest, CreateExchangeEffectiveRateCommandResponse>
    {
        readonly IExchangeEffectiveRateWriteService _exchangeEffectiveRateWriteService;

        public CreateExchangeEffectiveRateCommandHandler(IExchangeEffectiveRateWriteService exchangeEffectiveRateWriteService)
        {
            _exchangeEffectiveRateWriteService = exchangeEffectiveRateWriteService;
        }

        public async Task<CreateExchangeEffectiveRateCommandResponse> Handle(CreateExchangeEffectiveRateCommandRequest request, CancellationToken cancellationToken)
        {
            await _exchangeEffectiveRateWriteService.WriteDbExchangeEffectiveRateItems();
            return new();
        }
    }
}
