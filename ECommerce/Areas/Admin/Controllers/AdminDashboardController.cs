using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Index()
        {
            ViewBag.usercount = um.GetListAll().Count();
            ViewBag.productcount = pm.GetListAll().Count();
            ViewBag.messagecount = mm.GetListAll().Count();
            string api = "2b55960fb3cc42e0119e195986eee959";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
