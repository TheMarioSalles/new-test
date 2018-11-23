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
    [ViewComponent(Name = "Account")]
    public class AccountComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string clientId, string accountDocument)
        {
            AccountDto account = null;

            ViewData["ClientId"] = clientId;

            if (!String.IsNullOrWhiteSpace(accountDocument) && !String.IsNullOrEmpty(accountDocument))
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
                    var responseTask = await httpClient.GetAsync("Clients/" + clientId);
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var readTask = responseTask.Content.ReadAsAsync<ClientDto>();
                        readTask.Wait();
                        account = readTask.Result.Accounts.Where(x => x.Document == accountDocument).FirstOrDefault();
                    }
                    else { ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu..."); }
                }
            }
            return View("Account", account);
        }

        /*
        [HttpPost]
        public async Task<IViewComponentResult> Create(AccountDto account)
        {
            //account = Metodo1(account);
            using (var httpClient = new HttpClient())
            {
                var controllerName = "Accounts/create";
                var basicAccountApi = string.Format("http://localhost:53191/api/{0}", controllerName);
                //HTTP GET

                //StringContent strContent = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "aplication/json");

                //var packetData = account;
                //var jsonObj = new { json = packetData };

                var json = JsonConvert.SerializeObject(account); // no need to call `JObject.FromObject`
                //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(basicAccountApi, content);

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

            return Redirect("~/Accounts/AccountsList");
        }
        */

        //[HttpGet]
        //public IActionResult Update(string accountId)
        //{
        //    AccountDto account = null;

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri("http://localhost:53191/api/");
        //        //HTTP GET
        //        var responseTask = httpClient.GetAsync("Clients/" + accountId);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<AccountDto>();
        //            readTask.Wait();

        //            account = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            account = null;

        //            ModelState.AddModelError(string.Empty, "Ops... Algo inesperado ocorreu...");
        //        }
        //    }

        //    return View(account);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(AccountDto account)
        //{
        //    //AccountDto account = null;

        //    using (var httpClient = new HttpClient())
        //    {
        //        var controllerName = "Accounts/update";
        //        var basicAccountApi = string.Format("http://localhost:53191/api/{0}", controllerName);
        //        //HTTP GET

        //        //StringContent strContent = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "aplication/json");

        //        //var packetData = account;
        //        //var jsonObj = new { json = packetData };

        //        var json = JsonConvert.SerializeObject(account); // no need to call `JObject.FromObject`
        //        //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //        var response = await httpClient.PutAsync(basicAccountApi, content);


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

        //    return Redirect("~/Accounts/AccountsList");
        //}
    }
}