using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;

namespace Sow.Interfaces.AdminWAPP.Web.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var controllerName = "Users";
                    var methodName = "authenticate";
                    var basicClientApi = string.Format("http://localhost:53191/api/{0}/{1}", controllerName, methodName);

                    var json = JsonConvert.SerializeObject(userDto); // no need to call `JObject.FromObject`
                                                                     //json = "{ \"Name\":\"Mario\", \"Document\":\"123123123123\", \"AgentsQuantity\":\"10\", \"Status\":true }";
                    //var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var response = await httpClient.PostAsync(basicClientApi, content);
                    //HttpResponseMessage response = httpClient.PostAsync(basicClientApi, new StringContent(JsonConvert.SerializeObject(new {Username = userDto.Username, Password = userDto.Password }), Encoding.UTF8, "application/json")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        var user = JsonConvert.DeserializeObject<UserDto>(result);

                        //Helpers.SessionHelper.SetSession("Id", user.Id);
                        //Helpers.SessionHelper.SetSession("Token", user.Token);
                        //Helpers.SessionHelper.SetSession("Username", user.Username);

                        HttpContext.Session.SetString("Id", user.Id);
                        HttpContext.Session.SetString("Token", user.Token);
                        HttpContext.Session.SetString("Username", user.Username);

                        Redirect("~/Clients/ClientsList");

                        //AuthenticationProperties options = new AuthenticationProperties();

                        //options.AllowRefresh = true;
                        //options.IsPersistent = true;
                        ////options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token));

                        //var claims = new[]
                        //{
                        //    new Claim(ClaimTypes.Name, user.Username),
                        //    new Claim("AcessToken", string.Format("Bearer {0}", user.Token)),
                        //};

                        ////var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                        //Request.GetOwinContext().Authentication.SignIn(options, identity);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch(Exception e)
            {
                return Unauthorized();
            }
            
            return View();
        }
    }
}