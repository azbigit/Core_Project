using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class WriterUserController : Controller
    {
       WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ListUser()
        {
            //Ajax formatı
            //Listelemede Serialize kullanılır biz bir şey gönderirken de deserialize kullanılacak
            var value = JsonConvert.SerializeObject(writerUserManager.GetList());
            return Json(value); 
        }

        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            writerUserManager.TAdd(p);
            var value = JsonConvert.SerializeObject(p);
            return Json(value);
        }

    }
}
