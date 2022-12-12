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
        ShoppingCartManager scm = new ShoppingCartManager(new EfShoppingCartRepository());
        UserManager um = new UserManager(new EfUserRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();

            var selled = scm.GetListAll().ToList();
            var myproductformoney = pm.GetListAll().Where(x => x.UserId == userid).ToList();
            var mymoneytotal = 0;
            foreach (var item1 in myproductformoney)
            {
                foreach (var item2 in selled)
                {
                    if (item1.Id == item2.ProductId)
                    {
                        mymoneytotal += item2.Cost;
                    }
                }
            }
            mymoneytotal = mymoneytotal *100/118 ;
           
            ViewBag.mymoney = mymoneytotal;
            //ViewBag.mymoney = um.GetListAll().Count();
            ViewBag.productcount = pm.GetListAll().Where(x=>x.UserId==userid).Count();
            ViewBag.messagecount = mm.GetListAll().Where(x => x.MessageReceiver == userid || x.MessageSender==userid).Count();
            string api = "2b55960fb3cc42e0119e195986eee959";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
