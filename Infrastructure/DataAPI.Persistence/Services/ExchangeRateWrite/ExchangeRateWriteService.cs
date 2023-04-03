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

        public ExchangeRateWriteService(ITCMBExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public Task SetExchangeCrossRateItem()
        {
            throw new NotImplementedException();
        }

        public Task SetExchangeEffectiveRateItem()
        {
            throw new NotImplementedException();
        }

        public Task SetExchangeRateItem()
        {
            throw new NotImplementedException();
        }
    }
}
