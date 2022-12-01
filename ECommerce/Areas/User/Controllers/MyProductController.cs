using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    public class MyProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
