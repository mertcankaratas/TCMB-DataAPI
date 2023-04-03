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
        public int Unit { get; set; }
        public string FromCurrency { get; set; }
        public decimal CrossRate { get; set; }
        public string ToCurrency { get; set; }
        public DateTime Date { get; set; }
        public long UnixTime { get; set; }
    }
}
