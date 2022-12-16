using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminShopController : Controller
    {
        ShoppingCartManager shopm = new ShoppingCartManager(new EfShoppingCartRepository());
        public IActionResult Index()
        {
            var values = shopm.GetListAll();
            return View(values);
        }
    }
}
