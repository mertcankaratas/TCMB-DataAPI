using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeEffectiveRateWrite;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Enums.Exchange;
using DataAPI.Application.Repositories;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence.Services.ExchangeEffectiveRateWrite
{
    public class ExchangeEffectiveRateWriteService : IExchangeEffectiveRateWriteService
    {
        readonly ITCMBExchangeRateService _exchangeRateService;
        readonly IMapper _mapper;
        readonly IExchangeEffectiveRateWriteRepository _writeRepository;

        public ExchangeEffectiveRateWriteService(ITCMBExchangeRateService exchangeRateService, IMapper mapper, IExchangeEffectiveRateWriteRepository writeRepository)
        {
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public async Task WriteDbExchangeEffectiveRateItems()
        {
            foreach (ExchangeEffectiveCurrencyType type in Enum.GetValues(typeof(ExchangeEffectiveCurrencyType)))
            {
                List<ExchangeEffectiveRateItem> items = await _exchangeRateService.GetExchangeEffectiveData(type);

                List<Domain.Entities.ExchangeEffectiveRate> exchanges = _mapper.Map<List<ExchangeEffectiveRateItem>, List<Domain.Entities.ExchangeEffectiveRate>>(items);

                await _writeRepository.AddRangeAsync(exchanges);
                await _writeRepository.SaveAsync();
            }
        }
    }
}
