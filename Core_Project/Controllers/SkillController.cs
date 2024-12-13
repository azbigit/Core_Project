using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
         
            var values=skillManager.GetList();  
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill Skill) 
            {
           
            skillManager.TAdd(Skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
          
            var values = skillManager.GetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id) //güncellenecek değeri bulur 
        {
           
            var values = skillManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
