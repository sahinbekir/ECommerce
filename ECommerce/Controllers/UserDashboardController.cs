using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User")]
    public class UserDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
