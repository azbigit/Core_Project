using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        //MessageManager messageManager= new MessageManager(new EfMessageDal());

        public IViewComponentResult Invoke()
        {
            //var values = messageManager.GetList();
            return View();
        }
    
    }
}
