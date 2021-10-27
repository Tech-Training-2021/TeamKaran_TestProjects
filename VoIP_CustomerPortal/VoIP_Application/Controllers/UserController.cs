using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoIP_Application.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace VoIP_Application.Controllers
{
    public class UserController : Controller
    {
        string Baseurl = "https://localhost:44330/";
        public async Task<ActionResult> Index()
        {
            List<User> UserList = new List<User>();
            RootObject result = new RootObject();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/User");

                if (Res.IsSuccessStatusCode)
                {
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<RootObject>(UserResponse);
                    UserList = result.data.ToList();
                }
                
                return View(UserList);
            }
        }        

        public class RootObject
        {
            public string status { get; set; }
            public User[] data { get; set; }
        }
    }
}