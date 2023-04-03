using AutoMapper;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Abstraction.Services.ExchangeRateWrite;
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
        readonly IExchangeRateWriteService _exchangeRateWriteService;

        public ExchangeRateWriteService(ITCMBExchangeRateService exchangeRateService, IMapper mapper, IExchangeRateWriteService exchangeRateWriteService)
        {
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
            _exchangeRateWriteService = exchangeRateWriteService;
        }

        public Task WriteDbExchangeRateItems()
        {
            throw new NotImplementedException();
        }
    }
}
