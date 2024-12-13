using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNotificationNavBarList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
