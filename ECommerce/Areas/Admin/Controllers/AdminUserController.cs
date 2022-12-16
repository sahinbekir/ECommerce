using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        UserManager _userManager = new UserManager(new EfUserRepository());

        public IActionResult Index(int page = 1)
        {
            var values = _userManager.GetUserListWithCSG().ToPagedList(page, 8);
            return View(values);
        }
    }
}
