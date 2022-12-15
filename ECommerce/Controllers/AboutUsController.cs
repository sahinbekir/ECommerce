using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class AboutUsController : Controller
    {
        AboutUsManager aum = new AboutUsManager(new EfAboutUsRepository());
        public IActionResult Index()
        {
            var value = aum.GetListAll().Where(x=>x.IsDeleted==false).ToList();
            return View(value);
        }
    }
}
