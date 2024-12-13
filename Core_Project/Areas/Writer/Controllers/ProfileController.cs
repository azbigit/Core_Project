using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = value.Name;
            model.Surname = value.Surname;
            model.PictureURL = value.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if(User?.Identity.Name==null)
            //{
            //    return RedirectToAction("Default", "Index");
            //}
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory(); //Aktif yolu al
                var extension = Path.GetExtension(p.Picture.FileName);   //uzantıyı alır         
                var Imagename = Guid.NewGuid() + extension; // benzer olmayan resim adı oluşturulur
                var savelocation = resource + "/wwwroot/userimage/" + Imagename; //resmin kaydedileceği lokasyonu belirler
                var stream = new FileStream(savelocation, FileMode.Create);  //resim dosyası oluşturlur
                await p.Picture.CopyToAsync(stream); //resim doysasını kopyalar
                user.ImageUrl = Imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");   // eğer düzenleme işlemi başarılı olursa index e yöneltir
            }
            return View();
        }
    }
}
