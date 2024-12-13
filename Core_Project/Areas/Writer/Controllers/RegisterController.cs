using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core_Project.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p) //Oluşturduğumuz modelden parametre almasını istiyoruz
        {
            if(ModelState.IsValid) //Eğer değer geçerliyse
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.userName,
                    ImageUrl = p.ImageURL
                };

                if (p.ConfirmPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(w, p.Password); //Async metot ile metot kullandığımz için action da async olmalı


                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login"); 
                        // çalışırsa index sayfasında login e gelecek
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description); //çalışmazsa bizim modele gönderir
                        }
                    }
                }
            }
            return View();
        }
    }
}
