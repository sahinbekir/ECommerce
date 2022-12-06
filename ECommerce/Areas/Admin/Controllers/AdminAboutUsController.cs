using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}
