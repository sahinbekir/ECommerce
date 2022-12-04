using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    public class AdminContactUsController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        //List Del
        public IActionResult Index()
        {
            return View();
        }
    }
}
