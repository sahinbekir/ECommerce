using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        CityManager cm = new CityManager(new EfCityRepository());
        public IActionResult Index()
        {
            var values = cm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(City model)
        {
            cm.TAdd(model);
            return RedirectToAction("Index", "City");
        }
        [HttpGet]
        public IActionResult UpdateCity(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCity(City model)
        {
            cm.TUpdate(model);
            return RedirectToAction("Index", "City");
        }
        public IActionResult DeleteCategory(int id)
        {

            var value = cm.GetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index", "City");
        }
    }
}
