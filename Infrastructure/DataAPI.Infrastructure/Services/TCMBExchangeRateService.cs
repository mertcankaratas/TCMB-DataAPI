using DataAPI.Infrastructure.Deserialize;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Services
{
    public static class TCMBExchangeRateService
    {
        public static async Task<List<ExchangeRateItem>> GetData(string curencyType)
        {
           curencyType = curencyType.ToUpper();
            List<ExchangeRateItem> data = null;

            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih
                /*var url = $"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.USD.S&startDate={startDate}&endDate={endDate}&type=json&key=3ffIKbWqrT&frequence=2";*/      
                
                var url = $"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.USD.S&startDate={startDate}&endDate={endDate}&type=json&key=3ffIKbWqrT&frequence=2";


                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();



                JsonDocument jsonDoc = JsonDocument.Parse(content);

                ExchangeRates exchangeRates = new ExchangeRates();
                exchangeRates.totalCount = jsonDoc.RootElement.GetProperty("totalCount").GetInt32();
                exchangeRates.items = new List<ExchangeRateItem>();
                foreach (JsonElement item in jsonDoc.RootElement.GetProperty("items").EnumerateArray())
                {
                    IEnumerable<JsonProperty> properties = item.EnumerateObject();
                    if (properties.ElementAt(1).Value.GetString() != null)
                    {
                        int k = 0;
                        ExchangeRateItem exchangeRateItem = new ExchangeRateItem();



                        exchangeRateItem.Tarih = properties.ElementAt(k++).Value.GetString();
                        exchangeRateItem.Buy = properties.ElementAt(k++).Value.GetString(); ;
                        exchangeRateItem.Sell = properties.ElementAt(k++).Value.GetString();
                        exchangeRateItem.CurrencyCode = curencyType;
                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeRateItem.UnixTime = number;
                        exchangeRates.items.Add(exchangeRateItem);

                    }

                }



                data = exchangeRates.items;

            }


            return data;

        }

    }
}
