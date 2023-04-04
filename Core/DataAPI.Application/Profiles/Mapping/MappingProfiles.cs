using AutoMapper;
using DataAPI.Application.DTOs.ExchangeCrossRate;
using DataAPI.Application.DTOs.ExchangeEffectiveRate;
using DataAPI.Application.DTOs.ExchangeRate;
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
            // Dış api'dan gelen dataları entity nesnelerine map etme
            CreateMap<ExchangeRate, ExchangeRateItem>().ReverseMap();
            CreateMap<ExchangeEffectiveRate, ExchangeEffectiveRateItem>().ReverseMap();
            CreateMap<ExchangeCrossRate, ExchangeCrossRateItem>().ReverseMap();

            // Veritabanından entity'ler ile gelen dataları dto'lara map etme ve dışarıya öyle response olarak gönderme

            CreateMap<ExchangeCrossRate,ExchangeCrossRateListDTO>().ReverseMap();
            CreateMap<ExchangeRate,ExchangeRateListDTO>().ReverseMap();
            CreateMap<ExchangeEffectiveRate,ExchangeEffectiveRateListDTO>().ReverseMap();

        }
    }
}
