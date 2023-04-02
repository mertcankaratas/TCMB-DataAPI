using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Abstraction.Services.ExchangeRateWrite
{
    public interface IExchangeRateWriteService
    {
        Task SetExchangeRateItem();
        Task SetExchangeEffectiveRateItem();
        Task SetExchangeCrossRateItem();

    }
}
