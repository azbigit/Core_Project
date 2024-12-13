using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        //private readonly UserManager<WriterUser> _userManager;

        public IActionResult RecieverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var value = writerMessageManager.GetListRecieverMessage(p);
            return View(value);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var value = writerMessageManager.GetListSenderMessage(p);
            return View(value);
        }


        //public async Task<IActionResult> AdminMessagetDetails(string p)
        //{
        //    var value = writerMessageManager.GetById(int id);
        // //   var value = await _userManager.FindByNameAsync(User.Identity.Name);
        // //   ViewBag.p= value.ImageUrl;
        //    return View(value);
        //}


        public IActionResult AdminMessagetDetails(int id)
        {
            var value = writerMessageManager.GetById(id);
            return View(value);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var value = writerMessageManager.GetById(id);
            writerMessageManager.Delete(value);
            //return RedirectToAction("SenderMessageList");

            if (value.Sender=="admin@gmail.com")
            {
                return RedirectToAction("SenderMessageList");
            }

            else if (value.Reciver == "admin@gmail.com")
            {
                return RedirectToAction("RecieverMessageList");
            }
           else
            {
                return RedirectToAction("AdminMessageDelete");
            }
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
;           p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Reciver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            //kullanıcının e posta ad ve soyadını mesaj göndere çekmek için yazıldı
            p.ReciverName = usernamesurname;
            writerMessageManager.Insert(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
