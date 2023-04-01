using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Deserialize
{
    public enum CurrencyType
    {

        [EnumMember(Value = "TP.DK.USD.A-TP.DK.USD.S")]
        USD,
        [EnumMember(Value = "TP.DK.EUR.A-TP.DK.EUR.S")]
        EUR,
        [EnumMember(Value = "TP.DK.GPB.A-TP.DK.GPB.S")]
        GPB
    }
}
