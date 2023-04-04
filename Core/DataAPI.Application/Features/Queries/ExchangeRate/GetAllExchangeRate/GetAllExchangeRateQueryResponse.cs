using DataAPI.Application.DTOs.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeRate.GetAllExchangeRate
{
    public class GetAllExchangeRateQueryResponse
    {
        public List<ExchangeRateListDTO> Results { get; set; }
    }
}
