using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoIstProject.Business.Abstract;
using TodoIstProject.DataAccess.Concrete;
using TodoIstProject.Entities.Concrete;
using TodoIstProject.Entities.DTO;

namespace TodoIstProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        IRoleService _roleService;
        ITodoIstService _todoIstService;

        UserManager<AppUser> _userManager;
        RoleManager<UserRole> _roleManager;

        public AdminsController( IRoleService roleService,RoleManager<UserRole> roleManager,UserManager<AppUser> userManager,ITodoIstService todoIstService)
        {
            _roleService = roleService;
            _roleManager = _roleManager;
            _userManager = userManager;
            _todoIstService = todoIstService;
        }

        [HttpPost("addrole")]
        public ActionResult AddRole(AspNetRoles role)
        {
            var result = _roleService.Add(role);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("userlist")]
        public List<UserRoleDto> GetUserList()
        {
            var users = _userManager.Users.Select(x => new UserRoleDto()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Role = string.Join(",", _userManager.GetRolesAsync(x).Result.ToArray()),
                
            }).ToList();
            return users;
            //return Ok(users);
        }

        [HttpPost("adduserrole")]
        public ActionResult AddRoleUser(TodoIstTask todoIstTask)
        {
            var result = _todoIstService.Add(todoIstTask);
            return Ok();
        }
    }
}
