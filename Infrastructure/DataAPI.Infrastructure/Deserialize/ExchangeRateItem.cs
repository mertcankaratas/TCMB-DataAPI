using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize
{
    public class ExchangeRateItem
    {
        public string Tarih { get; set; }
        public string Buy { get; set; }
        public string Sell { get; set; }
        public long UnixTime { get; set; }
        public string CurrencyCode { get; set; }
    }
}
