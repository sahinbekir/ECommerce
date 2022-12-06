using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ECommerce.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        //SubCategoryManager scm = new SubCategoryManager(new EfSubCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category model)
        {
            model.CreatedDate= DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            cm.TAdd(model);
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            model.UpdatedDate= DateTime.Now;
            cm.TUpdate(model);
            return RedirectToAction("Index","Category");
        }
        public IActionResult DeleteCategory(int id)
        {
            
            var value = cm.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
                // We can do this with trigger.
                //var scvalues = scm.GetListAll().Where(x=>x.CategoryId==id).FirstOrDefault();
                //scm.TUpdate(scvalues);
            }
            else
            {
                value.IsDeleted = true;
                // We can do this with trigger.
                //var scvalues = scm.GetListAll().Where(x => x.CategoryId == id).FirstOrDefault();
                //scm.TUpdate(scvalues);
            }
            cm.TUpdate(value);
            return RedirectToAction("Index", "Category");
        }
    }
}
