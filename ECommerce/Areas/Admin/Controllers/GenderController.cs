using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}
/*
    public class BrandController : Controller
    {
        BrandManager bm = new BrandManager(new EfBrandRepository());
        public IActionResult Index()
        {
            var values = bm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            bm.TAdd(model);
            return RedirectToAction("Index", "Brand");
        }
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var values = bm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateBrand(Brand model)
        {
            model.UpdatedDate = DateTime.Now;
            bm.TUpdate(model);
            return RedirectToAction("Index", "Brand");
        }
        public IActionResult DeleteBrand(int id)
        {

            var value = bm.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            bm.TUpdate(value);
            return RedirectToAction("Index", "Brand");
        }
    }*/