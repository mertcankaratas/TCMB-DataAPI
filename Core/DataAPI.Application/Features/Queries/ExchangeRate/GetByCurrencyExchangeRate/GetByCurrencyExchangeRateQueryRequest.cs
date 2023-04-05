using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeRate.GetByCurrencyExchangeRate
{
    public class GetByCurrencyExchangeRateQueryRequest:IRequest<GetByCurrencyExchangeRateQueryResponse>
    {
        public string CurrencyCode { get; set; }
    }
}
