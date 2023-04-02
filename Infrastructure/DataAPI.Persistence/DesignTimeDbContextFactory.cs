using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAPI.Persistence.Contexts;

namespace DataAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExchangeRateDbContext>
    {
        public ExchangeRateDbContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<ExchangeRateDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
