using DataAPI.Application.Abstraction.Services.ExchangeCrossRateWrite;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Commands.ExchangeCrossRate.CreateExchangeCrossRate
{
    public class CreateExchangeCrossRateCommandHandler : IRequestHandler<CreateExchangeCrossRateCommandRequest, CreateExchangeCrossRateCommandResponse>
    {
        readonly IExchangeCrossRateWriteService _exchangeCrossRateWriteService;

        public CreateExchangeCrossRateCommandHandler(IExchangeCrossRateWriteService exchangeCrossRateWriteService)
        {
            _exchangeCrossRateWriteService = exchangeCrossRateWriteService;
        }

        public async Task<CreateExchangeCrossRateCommandResponse> Handle(CreateExchangeCrossRateCommandRequest request, CancellationToken cancellationToken)
        {
            await _exchangeCrossRateWriteService.WriteDbExchangeCrossRateItems();

            return new();
        }
    }
}
