using AutoMapper;
using DataAPI.Domain.Entities;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Profiles.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ExchangeRate, ExchangeRateItem>().ReverseMap();
            CreateMap<ExchangeEffectiveRate, ExchangeEffectiveRateItem>().ReverseMap();
            CreateMap<ExchangeCrossRate, ExchangeCrossRateItem>().ReverseMap();
        }
    }
}
