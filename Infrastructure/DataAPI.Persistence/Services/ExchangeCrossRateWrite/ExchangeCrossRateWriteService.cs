
using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeCrossRateWrite;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Enums.Exchange;
using DataAPI.Application.Repositories;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence.Services.ExchangeCrossRateWrite
{
    public class ExchangeCrossRateWriteService : IExchangeCrossRateWriteService
    {
        readonly ITCMBExchangeRateService _exchangeRateService;
        readonly IMapper _mapper;
        readonly IExchangeCrossRateWriteRepository _writeRepository;

        public ExchangeCrossRateWriteService(ITCMBExchangeRateService exchangeRateService, IMapper mapper, IExchangeCrossRateWriteRepository writeRepository)
        {
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public async Task WriteDbExchangeCrossRateItems()
        {
            foreach (ExchangeCrossCurrencyType type in Enum.GetValues(typeof(ExchangeCrossCurrencyType)))
            {
                List<ExchangeCrossRateItem> items = await _exchangeRateService.GetExchangeCrossData(type);

                List<Domain.Entities.ExchangeCrossRate> exchanges = _mapper.Map<List<ExchangeCrossRateItem>, List<Domain.Entities.ExchangeCrossRate>>(items);

                await _writeRepository.AddRangeAsync(exchanges);
                await _writeRepository.SaveAsync();
            }
        }
    }
}
