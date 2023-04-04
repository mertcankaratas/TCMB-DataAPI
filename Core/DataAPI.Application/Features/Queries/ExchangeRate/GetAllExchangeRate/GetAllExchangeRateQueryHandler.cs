using AutoMapper;
using DataAPI.Application.Abstraction.Services.Cache;
using DataAPI.Application.DTOs.ExchangeCrossRate;
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
        readonly ICacheService _cacheService;
        public GetAllExchangeRateQueryHandler(IMapper mapper, IExchangeRateReadRepository exchangeRateReadRepository, ICacheService cacheService)
        {
            _mapper = mapper;
            _exchangeRateReadRepository = exchangeRateReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetAllExchangeRateQueryResponse> Handle(GetAllExchangeRateQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheData = _cacheService.GetData<IEnumerable<ExchangeRateListDTO>>("ExchangeRate");
            List<ExchangeRateListDTO> result;
 

            if (cacheData != null && cacheData.Count() > 0)
            {
                result = cacheData.ToList();
            }
            else
            {
                var datas = _exchangeRateReadRepository.GetAll();
                result = _mapper.Map<List<ExchangeRateListDTO>>(datas);

                var expireTime = DateTimeOffset.Now.AddMinutes(10);

                _cacheService.SetData<IEnumerable<ExchangeRateListDTO>>("ExchangeRate", result, expireTime);

            }


            return new()
            {
                Results = result
            };
        }
    }
}
