using DataAPI.Application.Repositories;
using DataAPI.Domain.Entities;
using DataAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Persistence.Repositories
{
    public class ExchangeRateReadRepository : ReadRepository<ExchangeRate>, IExchangeRateReadRepository
    {
        public ExchangeRateReadRepository(ExchangeRateDbContext context) : base(context)
        {
        }
    }
}
