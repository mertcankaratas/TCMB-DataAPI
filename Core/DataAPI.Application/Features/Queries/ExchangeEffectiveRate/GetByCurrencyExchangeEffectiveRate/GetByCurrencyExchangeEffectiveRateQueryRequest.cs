using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetByCurrencyExchangeEffectiveRate
{
    public class GetByCurrencyExchangeEffectiveRateQueryRequest:IRequest<GetByCurrencyExchangeEffectiveRateQueryResponse>
    {
        public string Currency { get; set; }
    }
}
