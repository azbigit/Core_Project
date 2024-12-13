using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        private readonly SignInManager<WriterUser> _singInManger;

        public LoginController(SignInManager<WriterUser> singInManger)
        {
            _singInManger = singInManger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _singInManger.PasswordSignInAsync(p.UserName, p.Password, true, true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "Writer" });
                }
                else
                {
                    ModelState.AddModelError("","Hatalı Kullanıc adı ve şifre !");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _singInManger.SignOutAsync();
            return RedirectToAction("Index","Login");
        }
    }
}
