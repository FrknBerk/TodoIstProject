using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserManager<AppUser> _userManager;
        IUserService _userService;

        public UsersController(IUserService userService,UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("adduser")]
        public IActionResult Add(UserSignUp userSignUp)
        {
            AppUser appUser = new AppUser()
            {
                Email = userSignUp.Email,
                UserName = userSignUp.NameSurname,
            };
            var resultUser = _userManager.CreateAsync(appUser, userSignUp.Password);
            if (resultUser.Result.Succeeded == true)
            {

                return Ok(resultUser);
            }
            else
            {
                foreach (var item in resultUser.Result.Errors)
                {

                }
                return BadRequest(resultUser);
            }
            //var result = _userService.Add(user);
            //if (result.Success == true)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);
        }
    }
}
