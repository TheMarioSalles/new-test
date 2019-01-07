using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MarioLucci.Ituran.Domain.Dtos.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarioLucci.Ituran.Web.Models
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                IList<CurrencyDto> CurrencyDtos = new List<CurrencyDto>();
                using (HttpClient httpClient = new HttpClient())
                {
                    string controller = "Currency";
                    string basicClientApi = $"http://localhost:53191/api/{controller}";
                    HttpResponseMessage response = await httpClient.PostAsync(basicClientApi, null);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        CurrencyDtos = JsonConvert.DeserializeObject<IList<CurrencyDto>>(result);
                    }
                    return this.View(CurrencyDtos);
                }
            }
            catch
            {
                return this.View(new List<CurrencyDto>());
            }
        }
    }
}
