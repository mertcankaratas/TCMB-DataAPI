using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.DTOs.ExchangeEffectiveRate
{
    public class ExchangeEffectiveRateListDTO
    {
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string Currency { get; set; }
        public decimal ForexBuyying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuyying { get; set; }
        public decimal BanknoteSelling { get; set; }
        public DateTime Date { get; set; }
        public long UnixTime { get; set; }
    }
}
