using DataAPI.Application.Abstraction.Services.Cache;
using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Infrastructure.Services;
using DataAPI.Infrastructure.Services.Cache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructeServices(this IServiceCollection services)
        {
            services.AddSingleton<ITCMBExchangeRateService, TCMBExchangeRateService>();

            
            services.AddScoped<ICacheService, CacheService>();
        }
    }
}
