using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            //Ajax formatı
            //Listelemede Serialize kullanılır biz bir şey gönderirken de deserialize kullanılacak
            var values = JsonConvert.SerializeObject(experienceManager.GetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExperienceID)
        {
            var v =experienceManager.GetById(ExperienceID);
            var value = JsonConvert.SerializeObject(v);
            return Json(value); 
        }

        public IActionResult DeleteExperience(int ExperienceID)
        {
            var v = experienceManager.GetById(ExperienceID);
            experienceManager.TDelete(v);
            return NoContent(); // geriye bir şey döndürme
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience p)
        {
            var v = experienceManager.GetById(p.ExperienceID);
            experienceManager.TUpdate(v);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

    }
}
