using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates
{
    public class ExchangeEffectiveRateItem
    {
        public string CurrencyCode { get; set; }
        public string ForexBuyying { get; set; }
        public string ForexSelling { get; set; } 
        public string BanknoteBuyying { get; set; }
        public string BanknoteSelling { get; set; }
        public string Date { get; set; }
        public long UnixTime { get; set; }
    }
}
