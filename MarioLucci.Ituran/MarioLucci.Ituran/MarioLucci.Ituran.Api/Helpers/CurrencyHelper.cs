using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using MarioLucci.Ituran.Domain.Dtos.Entities;
using Newtonsoft.Json;

namespace MarioLucci.Ituran.Api.Helpers
{
    public static class CurrencyHelper
    {
        private static async Task<CurrencyLayerDto> GetQuotes()
        {
            try
            {
                CurrencyLayerDto result = new CurrencyLayerDto();
                using (HttpClient httpClient = new HttpClient())
                {
                    string access_keyParameter = "access_key";
                    string access_key = "7551725f19ea0c7a157d4e182a37484c";
                    string basicClientApi = $"http://www.apilayer.net/api/live?{access_keyParameter}={access_key}";
                    HttpResponseMessage httpResponse = await httpClient.PostAsync(basicClientApi, null);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string httpResult = httpResponse.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<CurrencyLayerDto>(httpResult);
                    }
                }
                return result;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return new CurrencyLayerDto();
            }
        }

        public static async Task<double> UsdToBrl(double dollarValue, double realValue)
        {
            try
            {
                return (dollarValue / realValue);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return 0;
            }
        }

        public static async Task<CurrencyDto> ConvertCurrency(string fromCurrency, string toCurrency)
        {
            try
            {
                CurrencyDto result = new CurrencyDto();
                CurrencyDto currencyDtoFrom = await CurrencyLayerToCurrency(fromCurrency);
                CurrencyDto currencyDtoTo = await CurrencyLayerToCurrency(toCurrency);
                double valueFrom = Convert.ToDouble(currencyDtoFrom.Value);
                double valueTo = Convert.ToDouble(currencyDtoTo.Value);
                currencyDtoTo.Value = (valueFrom / valueTo).ToString();
                result = currencyDtoTo;
                return result;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return new CurrencyDto();
            }
        }

        public static async Task<IList<CurrencyDto>> CurrencyLayerToCurrency()
        {
            try
            {
                QuotesDto quotesDto = (await GetQuotes()).quotes;
                IList<CurrencyDto> currencyDtos = new List<CurrencyDto>();
                foreach (PropertyInfo info in quotesDto.GetType().GetProperties())
                {
                    currencyDtos.Add(new CurrencyDto { Name = info.Name, ShortName = info.Name.Substring(3, 3), Value = info.GetValue(quotesDto, null).ToString() });
                }
                return currencyDtos;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return new List<CurrencyDto>();
            }
        }

        public static async Task<CurrencyDto> CurrencyLayerToCurrency(string shortName)
        {
            try
            {
                QuotesDto quotesDto = (await GetQuotes()).quotes;
                CurrencyDto currencyDto = new CurrencyDto();
                quotesDto.GetType().GetProperties().ToList().ForEach(x =>
                {
                    if (x.Name.Substring(3, 3).Equals(shortName))
                    {
                        PropertyInfo info = x;
                        currencyDto = new CurrencyDto { Name = info.Name, ShortName = info.Name.Substring(3, 3), Value = info.GetValue(quotesDto, null).ToString() };
                        return;
                    }
                });
                return currencyDto;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return new CurrencyDto();
            }
        }
    }
}
