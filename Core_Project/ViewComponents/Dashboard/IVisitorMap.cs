using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public interface IVisitorMap
    {
        ViewComponentResult Invoke();
    }
}