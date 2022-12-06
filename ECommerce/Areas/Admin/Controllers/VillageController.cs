using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VillageController : Controller
    {
        //CityManager cm = new CityManager(new EfCityRepository());
        VillageManager vm = new VillageManager(new EfVillageRepository());
        public IActionResult Index()
        {
            var values = vm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddVillage()
        {
            /*
            List<SelectListItem> cityvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.cv = cityvalues;*/
            return View();
        }
        [HttpPost]
        public IActionResult AddVillage(Village model)
        {
            vm.TAdd(model);
            return RedirectToAction("Index", "Village");
        }
        [HttpGet]
        public IActionResult UpdateVillage(int id)
        {
            var values = vm.GetById(id);
            /*
            List<SelectListItem> cityvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.cv = cityvalues;*/
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateVillage(Village model)
        {
            vm.TUpdate(model);
            return RedirectToAction("Index", "Village");
        }
        public IActionResult DeleteVillage(int id)
        {
            var value = vm.GetById(id);
            vm.TDelete(value);
            return RedirectToAction("Index", "Village");
        }
    }
}
