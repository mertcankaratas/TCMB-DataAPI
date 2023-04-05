using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetByCurrencyCrossRate
{
    public class GetByCurrencyCrossRateQueryRequest:IRequest<GetByCurrencyCrossRateQueryResponse>
    {
        public string CurrencyCode{ get; set; }
       
    }
}
