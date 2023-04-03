using DataAPI.Application.Enums.Exchange;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Abstraction.Services.ExchangeRateRead
{
    public interface ITCMBExchangeRateService
    {
        Task<List<ExchangeRateItem>> GetExchangeData(ExchangeCurrencyType curencyType);
        Task<List<ExchangeEffectiveRateItem>> GetExchangeEffectiveData(ExchangeEffectiveCurrencyType curencyType);


        Task<List<ExchangeCrossRateItem>> GetExchangeCrossData(ExchangeCrossCurrencyType curencyType);
    }
}
