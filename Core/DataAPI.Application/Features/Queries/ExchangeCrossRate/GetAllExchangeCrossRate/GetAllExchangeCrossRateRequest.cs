﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllExchangeCrossRate
{
    public class GetAllExchangeCrossRateRequest:IRequest<GetAllExchangeCrossRateResponse>
    {
    }
}
