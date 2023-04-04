using AutoMapper;
using DataAPI.Application.DTOs.ExchangeCrossRate;
using DataAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate
{
    public class GetAllCrossRateQueryHandler : IRequestHandler<GetAllCrossRateQueryRequest, GetAllCrossRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeCrossRateReadRepository _exchangeCrossRateReadRepository;

        public GetAllCrossRateQueryHandler(IMapper mapper, IExchangeCrossRateReadRepository exchangeCrossRateReadRepository)
        {
            _mapper = mapper;
            _exchangeCrossRateReadRepository = exchangeCrossRateReadRepository;
        }

        public async Task<GetAllCrossRateQueryResponse> Handle(GetAllCrossRateQueryRequest request, CancellationToken cancellationToken)
        {

            var datas = _exchangeCrossRateReadRepository.GetAll();

            List<ExchangeCrossRateListDTO> result = _mapper.Map<List<ExchangeCrossRateListDTO>>(datas);
            

            return new()
            {
                Results=result
            };
        }
    }
}
