using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserDashboardController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Index()
        {
            ViewBag.mymoney = 1373;
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y=>y.Id).FirstOrDefault();
            //ViewBag.mymoney = um.GetListAll().Count();
            ViewBag.productcount = pm.GetListAll().Where(x=>x.UserId==userid).Count();
            ViewBag.messagecount = mm.GetListAll().Where(x => x.MessageReceiver == userid || x.MessageSender==userid).Count();
            string api = "14ad2aba611dbef9c504b82a127794c5";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
