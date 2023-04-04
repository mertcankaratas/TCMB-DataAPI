using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetByCurrencyCodeCrossRate
{
    public class GetByCurrencyCrossRateQueryRequest:IRequest<GetByCurrencyCrossRateQueryResponse>
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}
