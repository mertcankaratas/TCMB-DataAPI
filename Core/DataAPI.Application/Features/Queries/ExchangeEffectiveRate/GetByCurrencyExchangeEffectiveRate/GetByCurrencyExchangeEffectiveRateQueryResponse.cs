using DataAPI.Application.DTOs.ExchangeEffectiveRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetByCurrencyExchangeEffectiveRate
{
    public class GetByCurrencyExchangeEffectiveRateQueryResponse
    {
        public List<ExchangeEffectiveRateListDTO> Results { get; set; }
    }
}
