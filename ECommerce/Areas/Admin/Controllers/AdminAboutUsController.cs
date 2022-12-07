using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAboutUsController : Controller
    {
        AboutUsManager aum = new AboutUsManager(new EfAboutUsRepository());
        public IActionResult Index()
        {
            var values = aum.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAboutUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAboutUs(AboutUs model)
        {
            model.ImageV1 = "/Media/eci1.png";
            model.ImageV2 = "/Media/eci2.png";
            model.MovieV1 = "/Media/ecm1.mp4";
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            aum.TAdd(model);
            return RedirectToAction("Index", "AdminAboutUs");
        }
        [HttpGet]
        public IActionResult UpdateAboutUs(int id)
        {
            var values = aum.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAboutUs(AboutUs model)
        {
            model.UpdatedDate = DateTime.Now;
            aum.TUpdate(model);
            return RedirectToAction("Index", "AdminAboutUs");
        }
        public IActionResult DeleteAboutUs(int id)
        {

            var value = aum.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            value.UpdatedDate = DateTime.Now;
            aum.TUpdate(value);
            return RedirectToAction("Index", "AdminAboutUs");
        }
    }
}
