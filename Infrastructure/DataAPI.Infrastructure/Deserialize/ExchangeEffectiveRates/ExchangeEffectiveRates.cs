using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates
{
    public class ExchangeEffectiveRates
    {
        public int totalCount { get; set; }
        public List<ExchangeEffectiveRateItem> items { get; set; }
    }
}
