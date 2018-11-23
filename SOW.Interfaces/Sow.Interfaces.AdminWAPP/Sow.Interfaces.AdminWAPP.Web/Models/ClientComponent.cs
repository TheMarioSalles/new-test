using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;

namespace Sow.Interfaces.AdminWAPP.Web.Models
{
    [ViewComponent(Name = "Client")]
    public class ClientComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string clientId)
        {
            ClientDto client = null;
            if (!String.IsNullOrWhiteSpace(clientId) && !String.IsNullOrEmpty(clientId))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                    var responseTask = await httpClient.GetAsync("Clients/" + clientId);
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var readTask = responseTask.Content.ReadAsAsync<ClientDto>();
                        readTask.Wait();
                        client = readTask.Result;
                    }
                    else { ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu..."); }
                }
            }
            return View("Client", client);
        }

        /*
        [HttpPost]
        public async Task<IViewComponentResult> Create(ClientDto client)
        {
            //client = Metodo1(client);
            using (var httpClient = new HttpClient())
            {
                var controllerName = "Clients/create";
                var basicClientApi = string.Format("http://localhost:53191/api/{0}", controllerName);
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");

                //var packetData = client;
                //var jsonObj = new { json = packetData };

                var json = JsonConvert.SerializeObject(client); // no need to call `JObject.FromObject`
                //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(basicClientApi, content);

                if (response.IsSuccessStatusCode)
                {
                    


                }
                else
                {
                    //TODO chamada de else
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                }

            }

            return Redirect("~/Clients/ClientsList");
        }
        */

        //[HttpGet]
        //public IActionResult Update(string clientId)
        //{
        //    ClientDto client = null;

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
        //        //HTTP GET
        //        var responseTask = httpClient.GetAsync("Clients/" + clientId);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<ClientDto>();
        //            readTask.Wait();

        //            client = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            client = null;

        //            ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
        //        }
        //    }

        //    return View(client);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(ClientDto client)
        //{
        //    //ClientDto client = null;

        //    using (var httpClient = new HttpClient())
        //    {
        //        var controllerName = "Clients/update";
        //        var basicClientApi = string.Format("http://localhost:53191/api/{0}", controllerName);
        //        //HTTP GET

        //        //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");

        //        //var packetData = client;
        //        //var jsonObj = new { json = packetData };

        //        var json = JsonConvert.SerializeObject(client); // no need to call `JObject.FromObject`
        //        //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //        var response = await httpClient.PutAsync(basicClientApi, content);


        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.StatusCode);
        //        }
        //        else
        //        {
        //            var rawResponse = await response.Content.ReadAsStringAsync();

        //            JObject o = JObject.Parse(rawResponse);
        //            Console.WriteLine(o.ToString());
        //        }

        //    }

        //    return Redirect("~/Clients/ClientsList");
        //}
    }
}