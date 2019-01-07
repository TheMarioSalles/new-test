using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MarioLucci.Ituran.Domain.Dtos.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarioLucci.Ituran.Web.Controllers
{
    public class CurrencyController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Exchange()
        {
            try
            {
                IList<CurrencyDto> CurrencyDtos = new List<CurrencyDto>();
                using (HttpClient httpClient = new HttpClient())
                {
                    string controller = "Currency";
                    string basicClientApi = $"http://localhost:53191/{controller}";
                    string json = JsonConvert.SerializeObject("");
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(basicClientApi, content);
                    //HttpResponseMessage response = httpClient.PostAsync(basicClientApi, new StringContent(JsonConvert.SerializeObject(new {Username = userDto.Username, Password = userDto.Password }), Encoding.UTF8, "application/json")).Result;

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