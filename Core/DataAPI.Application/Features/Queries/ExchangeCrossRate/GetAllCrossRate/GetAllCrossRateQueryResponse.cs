using DataAPI.Application.DTOs.ExchangeCrossRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate
{
    public class GetAllCrossRateQueryResponse
    {
      public List<ExchangeCrossRateListDTO> Results { get; set; }
    }
}
