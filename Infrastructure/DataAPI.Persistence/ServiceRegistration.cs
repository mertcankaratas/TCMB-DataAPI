using DataAPI.Application.Abstraction.Services.ExchangeEffectiveWrite;
using DataAPI.Application.Abstraction.Services.ExchangeRateWrite;
using DataAPI.Application.Repositories;
using DataAPI.Persistence.Contexts;
using DataAPI.Persistence.Repositories;
using DataAPI.Persistence.Services.ExchangeRateWrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ExchangeRateDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));


            services.AddScoped<IExchangeCrossRateReadRepository, ExchangeCrossRateReadRepository>();
            services.AddScoped<IExchangeCrossRateWriteRepository, ExchangeCrossRateWriteRepository>();

            services.AddScoped<IExchangeEffectiveRateReadRepository, ExchangeEffectiveRateReadRepository>();
            services.AddScoped<IExchangeEffectiveRateWriteRepository, ExchangeEffectiveRateWriteRepository>();

            services.AddScoped<IExchangeRateReadRepository, ExchangeRateReadRepository>();
            services.AddScoped<IExchangeRateWriteRepository, ExchangeRateWriteRepository>();


            services.AddScoped<IExchangeRateWriteService,ExchangeRateWriteService>();


        }
    }
}