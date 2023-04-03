using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Abstraction.Services.ExchangeRateWrite;
using DataAPI.Application.Enums.Exchange;
using DataAPI.Application.Repositories;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence.Services.ExchangeRateWrite
{
    public class ExchangeRateWriteService : IExchangeRateWriteService
    {
        readonly ITCMBExchangeRateService _exchangeRateService;
        readonly IMapper _mapper;
        readonly IExchangeRateWriteRepository _writeRepository;

        public ExchangeRateWriteService(ITCMBExchangeRateService exchangeRateService, IMapper mapper, IExchangeRateWriteRepository writeRepository)
        {
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public async Task WriteDbExchangeRateItems()
        {
            foreach(ExchangeCurrencyType type in Enum.GetValues(typeof(ExchangeCurrencyType)))
            {
                List<ExchangeRateItem> items = await _exchangeRateService.GetExchangeData(type);

                List<Domain.Entities.ExchangeRate> exchanges = _mapper.Map<List<ExchangeRateItem>, List<Domain.Entities.ExchangeRate>>(items);

                await _writeRepository.AddRangeAsync(exchanges);
                await _writeRepository.SaveAsync();
            }
            
        }
    }
}
