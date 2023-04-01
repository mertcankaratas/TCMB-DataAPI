using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize.ExchangeRates
{
    public class ExchangeRateItem
    {
        public string CurrencyCode { get; set; }
        public string ForexBuyying { get; set; }
        public string ForexSelling { get; set; }
        public string Date { get; set; }
        public long UnixTime { get; set; }
    }
}
