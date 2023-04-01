using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize
{
    public class ExchangeRates
    {
        public int totalCount { get; set; }
        public List<ExchangeRateItem> items { get; set; }
    }
}
