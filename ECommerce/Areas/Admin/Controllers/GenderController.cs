using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenderController : Controller
    {
        GenderManager gm = new GenderManager(new EfGenderRepository());
        public IActionResult Index()
        {
            var values = gm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGender()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGender(Gender model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            gm.TAdd(model);
            return RedirectToAction("Index", "Gender");
        }
        [HttpGet]
        public IActionResult UpdateGender(int id)
        {
            var values = gm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateGender(Gender model)
        {
            model.UpdatedDate = DateTime.Now;
            gm.TUpdate(model);
            return RedirectToAction("Index", "Gender");
        }
        public IActionResult DeleteGender(int id)
        {

            var value = gm.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            value.UpdatedDate = DateTime.Now;
            gm.TUpdate(value);
            return RedirectToAction("Index", "Gender");
        }
    }
}