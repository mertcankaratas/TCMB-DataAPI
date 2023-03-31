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
        public string ExchangeType { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public DateTime Date { get; set; }
    }
}
