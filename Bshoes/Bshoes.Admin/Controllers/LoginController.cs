using Bshoes.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bshoes.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Index(string username, string password)
        {
            var jsonObject = new JObject();
            jsonObject["Username"] = "admin";
            jsonObject["Password"] = "12345";
            var client = new HttpClient();
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = client.PostAsync("http://localhost:5000/api/Users/authenticate", content).Result;
            var contents = await result.Content.ReadAsStringAsync();
            var user =  JsonConvert.DeserializeObject<User>(contents);
            //ViewBag.token=content.
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
