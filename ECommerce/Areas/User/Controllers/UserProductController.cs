using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using ECommerce.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserProductController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        StockPieceManager sam = new StockPieceManager(new EfStockPieceRepository());
        
        

        public IActionResult Index(int page = 1)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductListWithCBU().Where(x => x.UserId != userid).ToPagedList(page, 8);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            ViewBag.pid = id;
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductById(id).Where(x => x.UserId != userid);
            return View(values);
        }
        

    }
}
