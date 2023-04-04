using DataAPI.Application.DTOs.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeRate.GetByCurrencyExchangeRate
{
    public class GetByCurrencyExchangeRateQueryResponse
    {
        public List<ExchangeRateListDTO> Results { get; set; }
    }
}
