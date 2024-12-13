using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging.Signing;
using System.Security.Cryptography.Xml;

namespace Core_Project.ViewComponents.Dashboard
{
    public class LastProjectStatistics:ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke( )
        {
            var value = portfolioManager.GetList().TakeLast(2).ToList();  
            return View(value); 

        }
    }
}
