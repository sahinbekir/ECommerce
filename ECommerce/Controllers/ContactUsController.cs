using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class ContactUsController : Controller
    {
        ContactUsManager cum = new ContactUsManager(new EfContactUsRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactUs cus)
        {
            cus.CreatedDate = DateTime.Now;
            cus.UpdatedDate = DateTime.Now;
            cus.IsDeleted = false;
            cum.TAdd(cus);
            return RedirectToAction("Index", "AboutUs");
        }
    }
}
