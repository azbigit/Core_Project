using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")] 
    //Bu URl i takip ederek işlem yapacak Aşağıda RedirecttoAction da belirtmeye gerek kalmaz
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]                      //mesaj detayını görmen için ekledik
        [Route("RecieverMessage")] 
        public async Task<IActionResult> RecieverMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = writerMessageManager.GetListRecieverMessage(p);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = writerMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }



        [Route("")]
        [Route("RecieverMessageDetails/{id}")]
        public IActionResult RecieverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.GetById(id);
            return View(writerMessage);
        }
        [Route("")]
        [Route("SenderMessageDetails/{id}")]

        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.GetById(id);
            return View(writerMessage);
        }
        
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
       
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string name = value.Name + "" + value.Surname; //gönderenin adı ve soyadı
            p.Sender = mail; //gönderenin maili
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x=>x.Email == p.Reciver).Select(y=>y.Name+" "+y.Surname).FirstOrDefault();
           //kullanıcının e posta ad ve soyadını mesaj göndere çekmek için yazıldı
            p.ReciverName = usernamesurname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());//bugünün tarihini alır
            writerMessageManager.Insert(p);
            return RedirectToAction("SenderMessage");  
            //senderMessage a yönlendirir 
        }
    }
}
