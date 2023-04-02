using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize.ExchangeCrossRates
{
    public class ExchangeCrossRates
    {
        public int totalCount { get; set; }
        public List<ExchangeCrossRateItem> items { get; set; }
    }
}
