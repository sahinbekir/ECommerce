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
    public class SubCategoryController : Controller
    {
        SubCategoryManager scm = new SubCategoryManager(new EfSubCategoryRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = scm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSubCategory()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult AddSubCategory(SubCategory model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            scm.TAdd(model);
            return RedirectToAction("Index", "SubCategory");
        }
        [HttpGet]
        public IActionResult UpdateSubCategory(int id)
        {
            var values = scm.GetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategory model)
        {
            model.UpdatedDate = DateTime.Now;
            scm.TUpdate(model);
            return RedirectToAction("Index", "SubCategory");
        }
        public IActionResult DeleteSubCategory(int id)
        {

            var value = scm.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            scm.TUpdate(value);
            return RedirectToAction("Index", "SubCategory");
        }
    }
}
