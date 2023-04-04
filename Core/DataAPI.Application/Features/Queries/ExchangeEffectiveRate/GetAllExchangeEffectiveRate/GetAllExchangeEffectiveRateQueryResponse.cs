using DataAPI.Application.DTOs.ExchangeEffectiveRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetAllExchangeEffectiveRate
{
    public class GetAllExchangeEffectiveRateQueryResponse
    {
        public List<ExchangeEffectiveRateListDTO> Results { get; set; }
    }
}
