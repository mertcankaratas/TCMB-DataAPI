using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Abstraction.Services.Exchange
{
    public interface ITCMBExchangeRateService
    {
        Task<List<ExchangeRateItem>> GetExchangData(string curencyType);
        Task<List<ExchangeEffectiveRateItem>> GetExchangEffectiveData(string curencyType);


        Task<List<ExchangeCrossRateItem>> GetExchangCrossData(string curencyType);
    }
}
