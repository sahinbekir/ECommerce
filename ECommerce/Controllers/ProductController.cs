using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            var values = pm.GetListAll();
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var values = pm.GetProductById(id);
            return View(values);
        }
    }
}