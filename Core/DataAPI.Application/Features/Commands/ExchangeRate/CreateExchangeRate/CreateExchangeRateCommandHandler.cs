using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
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
        readonly IExchangeRateWriteRepository _repository;
        readonly IMapper _mapper;
        readonly ITCMBExchangeRateService _rateService;

        public CreateExchangeRateCommandHandler(IExchangeRateWriteRepository repository, IMapper mapper, ITCMBExchangeRateService rateService)
        {
            _repository = repository;
            _mapper = mapper;
            _rateService = rateService;
        }

        public async Task<CreateExchangeRateCommandResponse> Handle(CreateExchangeRateCommandRequest request, CancellationToken cancellationToken)
        {
            List<ExchangeRateItem> items = await _rateService.GetExchangeData(Enums.Exchange.ExchangeCurrencyType.BGN);
            
            List<Domain.Entities.ExchangeRate> exchanges = _mapper.Map<List<ExchangeRateItem>, List<Domain.Entities.ExchangeRate>>(items);

            await _repository.AddRangeAsync(exchanges);
            await _repository.SaveAsync();
            
            return new();
        }
    }
}
