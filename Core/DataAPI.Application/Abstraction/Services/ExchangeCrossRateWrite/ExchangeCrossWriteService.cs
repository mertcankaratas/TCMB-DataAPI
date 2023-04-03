using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Abstraction.Services.ExchangeCrossRateWrite
{
    public interface ExchangeCrossWriteService
    {
        Task WriteDbExchangeCrossRateItems();
    }
}
