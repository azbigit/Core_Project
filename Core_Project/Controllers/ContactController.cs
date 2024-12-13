using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var value = messageManager.GetList();
            return View(value);
        }
        public IActionResult DeleteContact(int id)
        {
            var value = messageManager.GetById(id);
            messageManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var value = messageManager.GetById(id);
            return View(value);
        }
    }
}
