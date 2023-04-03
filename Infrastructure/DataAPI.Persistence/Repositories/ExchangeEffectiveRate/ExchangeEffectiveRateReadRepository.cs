using DataAPI.Application.Repositories;
using DataAPI.Domain.Entities;
using DataAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence.Repositories
{
    public class ExchangeEffectiveRateReadRepository : ReadRepository<ExchangeEffectiveRate>,IExchangeEffectiveRateReadRepository
    {
        public ExchangeEffectiveRateReadRepository(ExchangeRateDbContext context) : base(context)
        {
        }

        
    }
}
