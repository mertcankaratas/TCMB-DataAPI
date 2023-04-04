using AutoMapper;
using DataAPI.Application.DTOs.ExchangeRate;
using DataAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeRate.GetAllExchangeRate
{
    public class GetAllExchangeRateQueryHandler : IRequestHandler<GetAllExchangeRateQueryRequest, GetAllExchangeRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeRateReadRepository _exchangeRateReadRepository;

        public GetAllExchangeRateQueryHandler(IMapper mapper, IExchangeRateReadRepository exchangeRateReadRepository)
        {
            _mapper = mapper;
            _exchangeRateReadRepository = exchangeRateReadRepository;
        }

        public async Task<GetAllExchangeRateQueryResponse> Handle(GetAllExchangeRateQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _exchangeRateReadRepository.GetAll();

            List<ExchangeRateListDTO> result = _mapper.Map<List<ExchangeRateListDTO>>(datas);

            return new()
            {
                Results = result
            };
        }
    }
}
