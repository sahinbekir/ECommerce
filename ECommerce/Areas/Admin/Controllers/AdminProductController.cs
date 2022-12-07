using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult Index(int page = 1)
        {
            var values = pm.GetProductListWithCBU().ToPagedList(page, 8);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var values = pm.GetProductById(id);
            return View(values);
        }
    }
}
