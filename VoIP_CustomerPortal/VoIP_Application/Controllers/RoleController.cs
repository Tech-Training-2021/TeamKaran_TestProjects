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
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            HttpClient HC = new HttpClient();
            HC.BaseAddress = new Uri("https://localhost:44330/api/Role");

            var insertedRecord = HC.PostAsJsonAsync<Role>("Role", role);
            insertedRecord.Wait();

            var recordDisplay = insertedRecord.Result;

            if (recordDisplay.IsSuccessStatusCode)
            {
                return RedirectToAction("User", "Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetRoleById(int id)
        {
            Role role = new Role();
            RootObject result = new RootObject();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Role/"+ id.ToString());

                if (Res.IsSuccessStatusCode)
                {
                    var RoleResponse = Res.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<RootObject>(RoleResponse);
                    role = result.data;
                }

                return View(role);
            }
        }

        [HttpGet]
        public async Task<ActionResult> UpdateRole(int id)
        {
            Role role = new Role();
            RootObject result = new RootObject();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Role/" + id.ToString());

                if (Res.IsSuccessStatusCode)
                {
                    var RoleResponse = Res.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<RootObject>(RoleResponse);
                    role = result.data;
                }

                return View(role);
            }
        }

        [HttpPost]
        public ActionResult UpdateRole(Role role)
        {
            HttpClient HC = new HttpClient();
            HC.BaseAddress = new Uri("https://localhost:44330/api/Role");

            var insertedRecord = HC.PutAsJsonAsync<Role>("Role", role);
            insertedRecord.Wait();

            var recordDisplay = insertedRecord.Result;

            if (recordDisplay.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteRole(int id)
        {
            HttpClient HC = new HttpClient();
            HC.BaseAddress = new Uri("https://localhost:44330/api/");

            var insertedRecord = HC.DeleteAsync("Role/" + id.ToString());
            insertedRecord.Wait();

            var recordDisplay = insertedRecord.Result;

            if (recordDisplay.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        public class RootObject
        {
            public string status { get; set; }
            public Role data { get; set; }
        }
    }
}