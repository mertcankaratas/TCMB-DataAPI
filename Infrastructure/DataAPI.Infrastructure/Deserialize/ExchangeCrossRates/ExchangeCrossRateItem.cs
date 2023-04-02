using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize.ExchangeCrossRates
{
    public class ExchangeCrossRateItem
    {
        public string CurrencyCode { get; set; }
        public string Unit { get; set; }
        public string CrossRate { get; set; }
        public string Date { get; set; }
        public long UnixTime { get; set; }
    }
}
