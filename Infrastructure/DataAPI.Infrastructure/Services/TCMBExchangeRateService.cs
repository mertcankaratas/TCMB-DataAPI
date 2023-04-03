using DataAPI.Application.Abstraction.Services.ExchangeRateRead;
using DataAPI.Application.Enums.Exchange;
using DataAPI.Infrastructure.Deserialize.ExchangeCrossRates;
using DataAPI.Infrastructure.Deserialize.ExchangeEffectiveRates;
using DataAPI.Infrastructure.Deserialize.ExchangeRates;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
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
    public class TCMBExchangeRateService:ITCMBExchangeRateService
    {
        readonly IConfiguration _configuration;

        public TCMBExchangeRateService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ExchangeRateItem>> GetExchangeData(ExchangeCurrencyType curencyType)
        {
          
            List<ExchangeRateItem> data;

            var exchangeRateSection = _configuration.GetSection("ExchangeRate");

            var exchangetype = exchangeRateSection[$"Exchange:{curencyType}"];
            var apiKey = _configuration["ApiKey"];
            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih
                /*var url = $"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.USD.S&startDate={startDate}&endDate={endDate}&type=json&key=3ffIKbWqrT&frequence=2";*/

                var url = $"https://evds2.tcmb.gov.tr/service/evds/series={exchangetype}&startDate={startDate}&endDate={endDate}&type=json&key={apiKey}&frequence=2&decimalSeperator=,";


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



                        exchangeRateItem.Date = Convert.ToDateTime(properties.ElementAt(k++).Value.GetString());
                        exchangeRateItem.ForexBuyying = Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());
                        exchangeRateItem.ForexSelling = Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());
                 
                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeRateItem.UnixTime = number;
                        exchangeRates.items.Add(exchangeRateItem);

                        // appsetings json
                        exchangeRateItem.CurrencyCode = exchangeRateSection[$"CurrencyCode:{curencyType}"];
                        exchangeRateItem.Currency = exchangeRateSection[$"Currency:{curencyType}"];
                        exchangeRateItem.Unit = Convert.ToInt32(exchangeRateSection[$"Unit:{curencyType}"]);

                    }

                }



                data = exchangeRates.items;

            }


            return data;

        }




        public async Task<List<ExchangeEffectiveRateItem>> GetExchangeEffectiveData(ExchangeEffectiveCurrencyType curencyType)
        {
            
            List<ExchangeEffectiveRateItem> datas;

            var exchangeRateSection = _configuration.GetSection("ExchangeRate");
            var exchangetype = exchangeRateSection[$"EffectiveExchange:{curencyType}"];
            var apiKey = _configuration["ApiKey"];
            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih


                var url = $"https://evds2.tcmb.gov.tr/service/evds/series={exchangetype}&startDate={startDate}&endDate={endDate}&type=json&key={apiKey}&frequence=2&decimalSeperator=,";


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



                        exchangeEffectiveRateItem.Date = Convert.ToDateTime(properties.ElementAt(k++).Value.GetString());
                        exchangeEffectiveRateItem.ForexBuyying = Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());
                        exchangeEffectiveRateItem.ForexSelling =   Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());
                        exchangeEffectiveRateItem.BanknoteBuyying =Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());
                        exchangeEffectiveRateItem.BanknoteSelling =Convert.ToDecimal(properties.ElementAt(k++).Value.GetString());

                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeEffectiveRateItem.UnixTime = number;
                        exchangeEffectiveRates.items.Add(exchangeEffectiveRateItem);
                        
                        // appsetings json
                        exchangeEffectiveRateItem.CurrencyCode = exchangeRateSection[$"CurrencyCode:{curencyType}"];
                        exchangeEffectiveRateItem.Currency = exchangeRateSection[$"Currency:{curencyType}"];
                        exchangeEffectiveRateItem.Unit = Convert.ToInt32(exchangeRateSection[$"Unit:{curencyType}"]);
                    }

                }



                datas = exchangeEffectiveRates.items;

            }


            return datas;

        }



        public async Task<List<ExchangeCrossRateItem>> GetExchangeCrossData(ExchangeCrossCurrencyType curencyType)
        {
            
            List<ExchangeCrossRateItem> datas;

            var exchangeRateSection = _configuration.GetSection("CrossExchangeRate");

            var exchangetype = exchangeRateSection[$"CrossExchange:{curencyType}"];
            var apiKey = _configuration["ApiKey"];

            using (var client = new HttpClient())
            {
                var startDate = DateTime.Now.AddMonths(-2).ToString("dd-MM-yyyy"); // 2 ay önceki tarih
                var endDate = DateTime.Now.ToString("dd-MM-yyyy"); // bugünkü tarih


                var url = $"https://evds2.tcmb.gov.tr/service/evds/series={exchangetype}&startDate={startDate}&endDate={endDate}&type=json&key={apiKey}&frequence=2&decimalSeperator=,";


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
                        
                        ExchangeCrossRateItem exchangeCrossRateItem = new ExchangeCrossRateItem();



                        exchangeCrossRateItem.Date = Convert.ToDateTime(properties.ElementAt(0).Value.GetString());
                        //exchangeCrossRateItem.Unit = properties.ElementAt(k++).Value.GetString();
                        exchangeCrossRateItem.CrossRate = Convert.ToDecimal(properties.ElementAt(2).Value.GetString());


                      
                        long number;



                        JsonElement element = item.GetProperty("UNIXTIME");
                        long.TryParse(element.GetProperty("$numberLong").GetString(), out number);
                        exchangeCrossRateItem.UnixTime = number;
                        exchangeCrossRates.items.Add(exchangeCrossRateItem);

                        // appsetings
                        exchangeCrossRateItem.CurrencyCode = exchangeRateSection[$"CurrencyCode:{curencyType}"];
                        exchangeCrossRateItem.FromCurrency = exchangeRateSection[$"FromCurrency:{curencyType}"];
                        exchangeCrossRateItem.ToCurrency = exchangeRateSection[$"ToCurrency:{curencyType}"];
                        exchangeCrossRateItem.Unit = Convert.ToInt32(exchangeRateSection[$"Unit:{curencyType}"]);

                    }

                }



                datas = exchangeCrossRates.items;

            }


            return datas;

        }


    }

}