using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using TodoIstProject.Entities.Concrete;
using TodoIstProject.Entities.Model;
using TodoIstProject.WebAPI.Service.Task;

namespace TodoIstProject.UI.Controllers
{
    public class USerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                string user = HttpContext.Session.GetString("UserName");
                Login login = new Login()
                {
                    UserName = user,
                    Password = "0",
                };
                client.BaseAddress = new Uri(TodoIstProject.Entities.Urls.Url.RequestApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var serializeLogin = JsonConvert.SerializeObject(login);
                var data = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                HttpResponseMessage userResponse = await client.PostAsync("TodoIsts/getbyusername", data);
                if (userResponse.IsSuccessStatusCode)
                {
                    string responseBody = await userResponse.Content.ReadAsStringAsync();
                    List<TodoIstTask> tasks = JsonConvert.DeserializeObject<List<TodoIstTask>>(responseBody);
                    return View(tasks);
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<IActionResult> GetTaskById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient httpClient = new HttpClient(handler);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, TodoIstProject.Entities.Urls.Url.RequestApiUrl + "TodoIsts/getbyidtodo?id=" + id);
                HttpResponseMessage userResponse = await httpClient.SendAsync(request);
                if (userResponse.IsSuccessStatusCode)
                {
                    string responseBody = await userResponse.Content.ReadAsStringAsync();
                    TodoIstTask tasks = JsonConvert.DeserializeObject<TodoIstTask>(responseBody);
                    return View(tasks);
                }
                else
                {
                    return View();
                }
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetTaskById(TodoIstTask todoIstTask)
        {
            using (var client = new HttpClient())
            {
                bool update =TaskService.UpdateTask(todoIstTask);
                if (update)
                {
                    client.BaseAddress = new Uri(TodoIstProject.Entities.Urls.Url.RequestApiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var serializeLogin = JsonConvert.SerializeObject(todoIstTask);
                    var data = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                    HttpResponseMessage userResponse = await client.PostAsync("TodoIsts/update", data);
                    if (userResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "USer");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
