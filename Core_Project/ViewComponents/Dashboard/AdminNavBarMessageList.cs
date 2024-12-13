using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNavBarMessageList:ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var value = writerMessageManager.GetListRecieverMessage(p).OrderByDescending(x => x.WriterMessageID).Take(3).ToList();
            return View(value);
            //Son üç mesajı alır

        }

    }
}
