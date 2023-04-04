using DataAPI.Application.DTOs.ExchangeCrossRate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate
{
    public class GetAllCrossRateQueryRequest:IRequest<GetAllCrossRateQueryResponse>
    {
    }
}
