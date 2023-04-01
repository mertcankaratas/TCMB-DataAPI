using DataAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Domain.Entities
{
    public class ExchangeRate:BaseEntity
    {
        public string CurrencyCode { get; set; }
        public decimal ForexBuyying { get; set; }
        public decimal ForexSelling { get; set; }
        public DateTime Date { get; set; }
        public long UnixTime { get; set; }
    }
}
