using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
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
        public static async Task<List<ExchangeRateItem>> GetExchangData(string curencyType)
        {
            curencyType = curencyType.ToUpper();
            List<ExchangeRateItem> data;

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



                        exchangeRateItem.Date = properties.ElementAt(k++).Value.GetString();
                        exchangeRateItem.ForexBuyying = properties.ElementAt(k++).Value.GetString();
                        exchangeRateItem.ForexSelling = properties.ElementAt(k++).Value.GetString();
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




        public static async Task<List<ExchangeEffectiveRateItem>> GetExchangEffectiveData(string curencyType)
        {
            curencyType = curencyType.ToUpper();
            List<ExchangeEffectiveRateItem> datas;

            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih
              

                var url = $"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.GBP.A-TP.DK.GBP.S-TP.DK.GBP.A.EF-TP.DK.GBP.S.EF-&startDate={startDate}&endDate={endDate}&type=json&key=3ffIKbWqrT&frequency=2";


                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();



                JsonDocument jsonDoc = JsonDocument.Parse(content);

                ExchangeEffectiveRates exchangeEffectiveRates = new ExchangeEffectiveRates();
                exchangeEffectiveRates.totalCount = jsonDoc.RootElement.GetProperty("totalCount").GetInt32();
                exchangeEffectiveRates.items = new List<ExchangeEffectiveRateItem>();
                foreach (JsonElement item in jsonDoc.RootElement.GetProperty("items").EnumerateArray())
                {
                    IEnumerable<JsonProperty> properties = item.EnumerateObject();
                    if (properties.ElementAt(1).Value.GetString() != null)
                    {
                        int k = 0;
                        ExchangeEffectiveRateItem exchangeEffectiveRateItem = new ExchangeEffectiveRateItem();



                        exchangeEffectiveRateItem.Date = properties.ElementAt(k++).Value.GetString();
                        exchangeEffectiveRateItem.ForexBuyying = properties.ElementAt(k++).Value.GetString();
                        exchangeEffectiveRateItem.ForexSelling = properties.ElementAt(k++).Value.GetString();
                        exchangeEffectiveRateItem.BanknoteBuyying = properties.ElementAt(k++).Value.GetString();
                        exchangeEffectiveRateItem.BanknoteSelling = properties.ElementAt(k++).Value.GetString();
                                
                        exchangeEffectiveRateItem.CurrencyCode = curencyType;
                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeEffectiveRateItem.UnixTime = number;
                        exchangeEffectiveRates.items.Add(exchangeEffectiveRateItem);

                    }

                }



                datas = exchangeEffectiveRates.items;

            }


            return datas;

        }



        public static async Task<List<ExchangeCrossRateItem>> GetExchangCrossData(string curencyType)
        {
            curencyType = curencyType.ToUpper();
            List<ExchangeCrossRateItem> datas;

            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih


                var url = $"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.C-TP.DK.EUR.C&startDate={startDate}&endDate={endDate}&type=json&key=3ffIKbWqrT&frequency=2";


                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();



                JsonDocument jsonDoc = JsonDocument.Parse(content);

                ExchangeCrossRates exchangeCrossRates = new ExchangeCrossRates();
                exchangeCrossRates.totalCount = jsonDoc.RootElement.GetProperty("totalCount").GetInt32();
                exchangeCrossRates.items = new List<ExchangeCrossRateItem>();
                foreach (JsonElement item in jsonDoc.RootElement.GetProperty("items").EnumerateArray())
                {
                    IEnumerable<JsonProperty> properties = item.EnumerateObject();
                    if (properties.ElementAt(1).Value.GetString() != null)
                    {
                        int k = 0;
                        ExchangeCrossRateItem exchangeCrossRateItem = new ExchangeCrossRateItem();



                        exchangeCrossRateItem.Date = properties.ElementAt(k++).Value.GetString();
                        exchangeCrossRateItem.Unit = properties.ElementAt(k++).Value.GetString();
                        exchangeCrossRateItem.CrossRate = properties.ElementAt(k++).Value.GetString();
             

                        exchangeCrossRateItem.CurrencyCode = curencyType;
                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeCrossRateItem.UnixTime = number;
                        exchangeCrossRates.items.Add(exchangeCrossRateItem);

                    }

                }



                datas = exchangeCrossRates.items;

            }


            return datas;

        }


    }

}