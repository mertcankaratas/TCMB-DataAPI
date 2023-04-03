using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Abstraction.Services.ExchangeRateWrite;
using DataAPI.Application.Repositories;
using DataAPI.Domain.Entities;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Commands.ExchangeRate.CreateExchangeRate
{
    public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommandRequest, CreateExchangeRateCommandResponse>
    {
        readonly IExchangeRateWriteService _exchangeRateWriteService;

        public CreateExchangeRateCommandHandler(IExchangeRateWriteService exchangeRateWriteService)
        {
            _exchangeRateWriteService = exchangeRateWriteService;
        }

        public async Task<CreateExchangeRateCommandResponse> Handle(CreateExchangeRateCommandRequest request, CancellationToken cancellationToken)
        {

            await _exchangeRateWriteService.WriteDbExchangeRateItems();
            
            return new();
        }
    }
}
