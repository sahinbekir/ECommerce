using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserNewsProductController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        NewsProductManager npm = new NewsProductManager(new EfNewsProductRepository());
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = npm.GetListAll().Where(x => x.UserId == userid).ToList();
            return View(values);
        }
    }
}
