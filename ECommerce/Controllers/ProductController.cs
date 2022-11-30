using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;


namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult Index(int page = 1)
        {
            var values = pm.GetListAll().ToPagedList(page, 8);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            var values = pm.GetProductById(id);
            return View(values);
        }
    }
}