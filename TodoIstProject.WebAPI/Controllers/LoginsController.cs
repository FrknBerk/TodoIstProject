using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Entities.Concrete;

namespace TodoIstProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]
    public class LoginsController : ControllerBase
    {
        SignInManager<AppUser> _signInManager;
        UserManager<AppUser> _userManager;
        RoleManager<UserRole> _roleManager;

        public LoginsController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<UserRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("userlogin")]
        public async Task<AppUser> UserLogin(Login login)
        {
            //false ile çerezlerde hatırlasın mı diye sorduk
            //ikinci boolean değer kullanıcı sisteme 5 defa yanlış girerse belirli bir dakika sisteme girmesi yasaklanacak
            AppUser appUser = new AppUser()
            {
                UserName= login.UserName,
            };
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password,false,false);
            if (result.Succeeded)
            {
                
                var userRole = _userManager.FindByNameAsync(login.UserName);
                var user = await _userManager.FindByIdAsync(userRole.Result.Id.ToString());
                var role =await _userManager.GetRolesAsync(user);
                if (role[0] == "User")
                {
                    return user;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
            //var result = _loginService.UserLogin(login);
        }

        [HttpPost("adminLogin")]
        public async Task<ActionResult> AdminLogin(Login login)
        {
            AppUser appUser = new AppUser()
            {
                UserName = login.UserName,

            };
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (result.Succeeded)
            {

                var userRole = _userManager.FindByNameAsync(login.UserName);
                var user = await _userManager.FindByIdAsync(userRole.Result.Id.ToString());
                var role = await _userManager.GetRolesAsync(user);
                if (role[0] == "Admin")
                {
                    return Ok(result);
                }
                else
                    return BadRequest();

            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
