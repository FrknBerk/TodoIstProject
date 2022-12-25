using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Entities.Concrete;
using TodoIstProject.Entities.Model;
using TodoIstProject.WebAPI.Service.Task;

namespace TodoIstProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoIstsController : ControllerBase
    {
        ITodoIstService _todoIstService;
        UserManager<AppUser> _userManager;

        public TodoIstsController(ITodoIstService todoIstService, UserManager<AppUser> userManager)
        {
            _todoIstService = todoIstService;
            _userManager = userManager;
        }
        [HttpPost("add")]
        public bool Add(TodoIstTask todoIstTask)
        {
            var result = _todoIstService.Add(todoIstTask);
            if (result.Success == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _todoIstService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getbyusername")]
        public List<TodoIstTask> GetByUserId(Login login)
        {
            var userRole = _userManager.FindByNameAsync(login.UserName);
            var result = _todoIstService.GetById(userRole.Result.Id);
            return result;
        }

        [HttpPost("getbyidtodo")]
        public TodoIstTask GetByIdTodo(int id)
        {
            var result = _todoIstService.GetByIdTodo(id);
            return result;
        }

        [HttpPost("update")]
        public bool Update(TodoIstTask todoIstTask)
        {
            var result = _todoIstService.Update(todoIstTask);
            if(result == true)
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
