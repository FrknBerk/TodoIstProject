using Microsoft.OpenApi.Models;
using RestSharp;
using TodoIstProject.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using TodoIstProject.Entities.Model;
using Newtonsoft.Json;
using TodoIstProject.Entities.Urls;

namespace TodoIstProject.WebAPI.Service.Task
{
    public class TaskService
    {
        private static IConfiguration _configuration;
        public TaskService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string token = "TOKEN DEĞERİ GİRİLMELİ";
        public static string TodoIstToken()
        {
            //var todoIstToken = _configuration.GetValue<string>("todoIstToken");
            var todoIstToken = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("settings")["todoIstToken"];
            return todoIstToken;
        }

        public static AddTaskResponse AddTask(TodoIstTask todoIstTask)
        {
            var client = new RestClient(Url.TodoIstTaskUrl + "tasks");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "csrf=32ba91dfbdb54deaa4ed5b712619a4b7");
            var body = @"{
            ""content"":""" + todoIstTask.Title + @""",
            ""description"":""" + todoIstTask.Description + @""",
            ""labels"":[""#test"",""deneme""],
            ""due_date"":""" + todoIstTask.FinishDate.ToString("yyyy-MM-dd") + @""",
            ""due_lang"":""tr"",
            ""priority"":3,
            ""is_completed"": """ + todoIstTask.IsCompleted + @"""
            }";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                AddTaskResponse taskResponse = JsonConvert.DeserializeObject<AddTaskResponse>(response.Content);
                return taskResponse;
            }
            else
                return null;
        }

        public static bool UpdateTask(TodoIstTask todoIstTask)
        {
            var client = new RestClient();
            var request = new RestRequest(Method.POST);
            var body = "";
            if (todoIstTask.IsCompleted)
            {
                client = new RestClient(Url.TodoIstTaskUrl + "tasks/" + todoIstTask.CreateTaskId + "/close");
                client.Timeout = -1;
                request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Cookie", "csrf=32ba91dfbdb54deaa4ed5b712619a4b7");
                body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
            }
            else
            {
                client = new RestClient(Url.TodoIstTaskUrl + "tasks/" + todoIstTask.CreateTaskId);
                client.Timeout = -1;
                request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", "csrf=32ba91dfbdb54deaa4ed5b712619a4b7");
                body = @"{
            ""description"":""" + todoIstTask.Description + @""",
            ""labels"":[""#etiketler"",""açıklama""],
            ""due_date"":""" + todoIstTask.FinishDate.ToString("yyyy-MM-dd") + @""",
            ""due_lang"":""tr"",
            ""priority"":2,
            ""is_completed"": false  0
            }";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
