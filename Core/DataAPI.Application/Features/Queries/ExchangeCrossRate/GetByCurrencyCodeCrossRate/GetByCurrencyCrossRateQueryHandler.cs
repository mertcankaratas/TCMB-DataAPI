using AutoMapper;
using DataAPI.Application.Abstraction.Services.Cache;
using DataAPI.Application.DTOs.ExchangeCrossRate;
using DataAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetByCurrencyCodeCrossRate
{
    public class GetByCurrencyCrossRateQueryHandler : IRequestHandler<GetByCurrencyCrossRateQueryRequest, GetByCurrencyCrossRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeCrossRateReadRepository _exchangeCrossRateReadRepository;
        readonly ICacheService _cacheService;

        public GetByCurrencyCrossRateQueryHandler(IMapper mapper, IExchangeCrossRateReadRepository exchangeCrossRateReadRepository, ICacheService cacheService)
        {
            _mapper = mapper;
            _exchangeCrossRateReadRepository = exchangeCrossRateReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetByCurrencyCrossRateQueryResponse> Handle(GetByCurrencyCrossRateQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheData = _cacheService.GetData<IEnumerable<ExchangeCrossRateListDTO>>($"CrossRate{request.FromCurrency}To{request.ToCurrency}");
            List<ExchangeCrossRateListDTO> result;
            if (cacheData != null && cacheData.Count() > 0)
            {
                result = cacheData.ToList();
            }
            else
            {
                var datas = _exchangeCrossRateReadRepository.GetWhere(x => x.FromCurrency == request.FromCurrency && x.ToCurrency == request.ToCurrency);

                result = _mapper.Map<List<ExchangeCrossRateListDTO>>(datas);

                var expireTime = DateTimeOffset.Now.AddMinutes(10);

                _cacheService.SetData<IEnumerable<ExchangeCrossRateListDTO>>($"CrossRate{request.FromCurrency}To{request.ToCurrency}", result, expireTime);


            }



            return new()
            {
                Results = result
            };
        }
    }
}
