using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;

namespace Sow.Interfaces.AdminWAPP.Web.Controllers
{
    //[Authorize("Bearer")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientsController : Controller
    {
        //[AllowAnonymous]
        public IActionResult ClientsList()
        {
            IEnumerable<ClientDto> Clients = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                //HTTP GET
                var responseTask = httpClient.GetAsync("Clients");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ClientDto>>();
                    readTask.Wait();

                    Clients = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Clients = Enumerable.Empty<ClientDto>();

                    ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
                }
            }
            return View(Clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult EndPoint()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDto client)
        {
            //client = Metodo1(client);
            client = await Metodo3(client);
            return Redirect("~/Clients/ClientsList");
        }

        private ClientDto Metodo1(ClientDto client)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");


                string clientJson = JsonConvert.SerializeObject(client);

                byte[] clientBytes = Encoding.UTF8.GetBytes(clientJson);

                var content = new ByteArrayContent(clientBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("aplication/json");
                //JsonResult json = new JsonResult(client);

                var responseTask = httpClient.PostAsync("Clients/create", content);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClientDto>();
                    readTask.Wait();

                    client = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
                }
            }

            return client;
        }

        private async Task<ClientDto> Metodo2(ClientDto client)
        {
            using (var httpClient = new HttpClient())
            {
                var controllerName = "Clients/create";
                var basicClientApi = string.Format("http://localhost:53191/api/{0}", controllerName);
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");

                var packetData = client;
                var jsonObj = new { json = packetData };

                var json = JsonConvert.SerializeObject(jsonObj); // no need to call `JObject.FromObject`
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(basicClientApi, content);


                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                    Console.WriteLine(o.ToString());
                }

            }

            return client;
        }

        private async Task<ClientDto> Metodo3(ClientDto client)
        {
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
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                    Console.WriteLine(o.ToString());
                }

            }

            return client;
        }

        [HttpGet]
        public IActionResult Update(string clientId)
        {
            ClientDto client = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                //HTTP GET
                var responseTask = httpClient.GetAsync("Clients/" + clientId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClientDto>();
                    readTask.Wait();

                    client = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    client = null;

                    ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
                }
            }

            return View(client);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(ClientDto client)
        {
            //ClientDto client = null;

            using (var httpClient = new HttpClient())
            {
                var controllerName = "Clients/update";
                var basicClientApi = string.Format("http://localhost:53191/api/{0}", controllerName);
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");

                //var packetData = client;
                //var jsonObj = new { json = packetData };

                var json = JsonConvert.SerializeObject(client); // no need to call `JObject.FromObject`
                //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync(basicClientApi, content);


                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                    Console.WriteLine(o.ToString());
                }

            }

            return Redirect("~/Clients/ClientsList");
        }

        #region Account

        public IActionResult ClientAccounts(string clientId)
        {
            ClientDto client = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                //HTTP GET
                var responseTask = httpClient.GetAsync("Clients/" + clientId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClientDto>();
                    readTask.Wait();

                    client = readTask.Result;

                    ViewData["ClientId"] = client.Id;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    client = null;

                    ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
                }
            }

            return View(client.Accounts);
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount(string clientId, AccountDto account)
        {
            AccountDto client = null;

            using (var httpClient = new HttpClient())
            {
                var controllerName = "Clients/addaccount";
                var basicClientApi = string.Format("http://localhost:53191/api/{0}/{1}", controllerName, clientId);
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "aplication/json");

                //var packetData = client;
                //var jsonObj = new { json = packetData };

                var json = JsonConvert.SerializeObject(account); // no need to call `JObject.FromObject`
                //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync(basicClientApi, content);


                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                    Console.WriteLine(o.ToString());
                }

                //httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                //var responseTask = httpClient.GetAsync("Clients/" + clientId);
                //responseTask.Wait();

                //var result = responseTask.Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    var readTask = result.Content.ReadAsAsync<ClientDto>();
                //    readTask.Wait();
                //    client = readTask.Result;
                //    var controllerName = "Clients/update";
                //    var basicClientApi = string.Format("http://localhost:53191/api/{0}", controllerName);
                //    var json = JsonConvert.SerializeObject(client);
                //    var content = new StringContent(json, Encoding.UTF8, "application/json");
                //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //    var response = await httpClient.PutAsync(basicClientApi, content);

                //    if (response.IsSuccessStatusCode) { } else { }
                //}
                //else { ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu..."); }
            }

            return Redirect(String.Concat("~/Clients/ClientAccounts/?clientId=", clientId));
        }

        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(string clientId, AccountDto account)
        {
            using (var httpClient = new HttpClient())
            {
                var controllerName = "Clients";
                var methodName = "updateaccount";
                var basicClientApi = string.Format("http://localhost:53191/api/{0}/{1}/{2}", controllerName, methodName, clientId);

                var json = JsonConvert.SerializeObject(account);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync(basicClientApi, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();

                    JObject o = JObject.Parse(rawResponse);
                    Console.WriteLine(o.ToString());
                }

            }
            return Redirect(String.Concat("~/Clients/ClientAccounts/?clientId=", clientId));
        }

        #endregion
    }
}