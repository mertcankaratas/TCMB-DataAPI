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
    public class ExchangeEffectiveRateWriteRepository : WriteRepository<ExchangeEffectiveRate>, IExchangeEffectiveRateWriteRepository
    {
        public ExchangeEffectiveRateWriteRepository(ExchangeRateDbContext context) : base(context)
        {
        }
    }
}
