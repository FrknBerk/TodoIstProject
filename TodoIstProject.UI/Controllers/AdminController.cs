using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Business.Concrete;
using TodoIstProject.Entities.Concrete;
using TodoIstProject.Entities.DTO;
using TodoIstProject.Entities.Model;
using TodoIstProject.WebAPI.Service.Task;

namespace TodoIstProject.UI.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserRoleDto> users = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(TodoIstProject.Entities.Urls.Url.RequestApiUrl);
                var userResponse = client.GetAsync("Admins/userlist");
                userResponse.Wait();
                var result = userResponse.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserRoleDto>>();
                    readTask.Wait();
                    users = readTask.Result;

                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var item in users)
                    {
                        list.Add(new SelectListItem()
                        {
                            Text = item.UserName,
                            Value = item.Id.ToString(),
                        });
                    }
                    ViewBag.UserList = list;

                    return View();
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(TodoIstTask todoIstTask)
        {
            using (var client = new HttpClient())
            {
                AddTaskResponse taskResponse = TaskService.AddTask(todoIstTask);
                if (taskResponse != null)
                {
                    todoIstTask.CreateDate = DateTime.Now;
                    todoIstTask.RefreshDate = DateTime.Now;
                    todoIstTask.CreateTaskId = taskResponse.id;
                    client.BaseAddress = new Uri(TodoIstProject.Entities.Urls.Url.RequestApiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var serializeLogin = JsonConvert.SerializeObject(todoIstTask);
                    var data = new StringContent(serializeLogin, Encoding.UTF8, "application/json");
                    HttpResponseMessage userResponse = await client.PostAsync("TodoIsts/add", data);
                    if (userResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Admin");
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
