using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core_Project.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {

        ServiceManager serviceManager = new ServiceManager(new EfServiseDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.GetList();
            return View(values);
        }
    }
}
