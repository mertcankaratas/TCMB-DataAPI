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

namespace DataAPI.Application.Features.Queries.ExchangeCrossRate.GetAllCrossRate
{
    public class GetAllCrossRateQueryHandler : IRequestHandler<GetAllCrossRateQueryRequest, GetAllCrossRateQueryResponse>
    {
        readonly IMapper _mapper;
        readonly IExchangeCrossRateReadRepository _exchangeCrossRateReadRepository;
        readonly ICacheService _cacheService;


        public GetAllCrossRateQueryHandler(IMapper mapper, IExchangeCrossRateReadRepository exchangeCrossRateReadRepository, ICacheService cacheService)
        {
            _mapper = mapper;
            _exchangeCrossRateReadRepository = exchangeCrossRateReadRepository;
            _cacheService = cacheService;
        }

        public async Task<GetAllCrossRateQueryResponse> Handle(GetAllCrossRateQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheData = _cacheService.GetData<IEnumerable<ExchangeCrossRateListDTO>>("ExchangeCrossRate");
            List<ExchangeCrossRateListDTO> result;
            if (cacheData !=null && cacheData.Count() > 0)
            {
                result = cacheData.ToList();
            }
            else
            {
                var datas = _exchangeCrossRateReadRepository.GetAll();

                result = _mapper.Map<List<ExchangeCrossRateListDTO>>(datas);

                var expireTime = DateTimeOffset.Now.AddMinutes(10);

                _cacheService.SetData<IEnumerable<ExchangeCrossRateListDTO>>("ExchangeCrossRate",result,expireTime);


            }

           

            return new()
            {
                Results=result
            };
        }
    }
}
