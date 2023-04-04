using AutoMapper;
using DataAPI.Application.Abstraction.Services.Cache;
using DataAPI.Application.DTOs.ExchangeCrossRate;
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
        readonly ICacheService _cacheService;
        public GetAllExchangeEffectiveRateQueryHandler(IMapper mapper, IExchangeEffectiveRateReadRepository exchangeEffectiveRateReadRepository, ICacheService cacheService)
        {
            _mapper = mapper;
            _exchangeEffectiveRateReadRepository = exchangeEffectiveRateReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetAllExchangeEffectiveRateQueryResponse> Handle(GetAllExchangeEffectiveRateQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheData = _cacheService.GetData<IEnumerable<ExchangeEffectiveRateListDTO>>("ExchangeEffectiveRate");
            List<ExchangeEffectiveRateListDTO> result;

            if (cacheData != null && cacheData.Count() > 0)
            {
                result = cacheData.ToList();
            }
            else
            {
                var datas = _exchangeEffectiveRateReadRepository.GetAll();

                result = _mapper.Map<List<ExchangeEffectiveRateListDTO>>(datas);
               
                var expireTime = DateTimeOffset.Now.AddMinutes(10);

                _cacheService.SetData<IEnumerable<ExchangeEffectiveRateListDTO>>("ExchangeEffectiveRate", result, expireTime);

            }
           

            return new()
            {
                Results = result
            };
        }
    }
}
