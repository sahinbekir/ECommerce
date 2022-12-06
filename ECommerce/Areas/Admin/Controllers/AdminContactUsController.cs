using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminContactUsController : Controller
    {
        ContactUsManager cum = new ContactUsManager(new EfContactUsRepository());
        public IActionResult Index()
        {
            var values = cum.GetListAll();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var value = cum.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            value.UpdatedDate = DateTime.Now;
            cum.TUpdate(value);
            return RedirectToAction("Index", "AdminContactUs");
        }
    }
}
