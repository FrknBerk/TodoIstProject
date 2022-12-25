using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TodoIstProject.Entities.Concrete;
using TodoIstProject.UI.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TodoIstProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(TodoIstProject.Entities.Urls.Url.RequestApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var serializeLogin = JsonConvert.SerializeObject(login);
                var data =new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                HttpResponseMessage userResponse = await client.PostAsync("Logins/userlogin",data);
                HttpResponseMessage adminResponse = await client.PostAsync("Logins/adminLogin", data);
                if(userResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("UserName", login.UserName);
                    return RedirectToAction("Index", "USer");
                }
                else if (adminResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Admin"); 
                }
                else
                {
                    return View();
                }
            }
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}