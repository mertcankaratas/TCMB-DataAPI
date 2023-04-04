using AutoMapper;
using DataAPI.Application.Abstraction.Services.Cache;
using DataAPI.Application.DTOs.ExchangeEffectiveRate;
using DataAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeEffectiveRate.GetByCurrencyExchangeEffectiveRate
{
    public class GetByCurrencyExchangeEffectiveRateQueryHandler : IRequestHandler<GetByCurrencyExchangeEffectiveRateQueryRequest, GetByCurrencyExchangeEffectiveRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeEffectiveRateReadRepository _exchangeEffectiveRateReadRepository;
        readonly ICacheService _cacheService;

        public GetByCurrencyExchangeEffectiveRateQueryHandler(IMapper mapper, IExchangeEffectiveRateReadRepository exchangeEffectiveRateReadRepository, ICacheService cacheService)
        {
            _mapper = mapper;
            _exchangeEffectiveRateReadRepository = exchangeEffectiveRateReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetByCurrencyExchangeEffectiveRateQueryResponse> Handle(GetByCurrencyExchangeEffectiveRateQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheData = _cacheService.GetData<IEnumerable<ExchangeEffectiveRateListDTO>>($"EffectiveRate{request.Currency}");
            List<ExchangeEffectiveRateListDTO> result;

            if (cacheData != null && cacheData.Count() > 0)
            {
                result = cacheData.ToList();
            }
            else
            {
                var datas = _exchangeEffectiveRateReadRepository.GetWhere(x=>x.Currency==request.Currency);

                result = _mapper.Map<List<ExchangeEffectiveRateListDTO>>(datas);

                var expireTime = DateTimeOffset.Now.AddMinutes(10);

                _cacheService.SetData<IEnumerable<ExchangeEffectiveRateListDTO>>($"EffectiveRate{request.Currency}", result, expireTime);

            }


            return new()
            {
                Results = result
            };
        }
    }
}
