using AutoMapper;
using DataAPI.Application.DTOs.ExchangeEffectiveRate;
using DataAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetAllExchangeEffectiveRate
{
    public class GetAllExchangeEffectiveRateQueryHandler : IRequestHandler<GetAllExchangeEffectiveRateQueryRequest, GetAllExchangeEffectiveRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeEffectiveRateReadRepository _exchangeEffectiveRateReadRepository;

        public GetAllExchangeEffectiveRateQueryHandler(IMapper mapper, IExchangeEffectiveRateReadRepository exchangeEffectiveRateReadRepository)
        {
            _mapper = mapper;
            _exchangeEffectiveRateReadRepository = exchangeEffectiveRateReadRepository;
        }

        public async Task<GetAllExchangeEffectiveRateQueryResponse> Handle(GetAllExchangeEffectiveRateQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _exchangeEffectiveRateReadRepository.GetAll();

            List<ExchangeEffectiveRateListDTO> result = _mapper.Map<List<ExchangeEffectiveRateListDTO>>(datas);

            return new()
            {
                Results = result
            };
        }
    }
}
