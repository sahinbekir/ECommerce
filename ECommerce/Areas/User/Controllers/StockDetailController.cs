using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class StockDetailController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        StockPieceManager spm = new StockPieceManager(new EfStockPieceRepository());
        [HttpGet]
        public IActionResult Index(int id)
        {
            var check = spm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            var pname = pm.GetListAll().Where(x => x.Id == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.pid = id;
            @ViewBag.pname = pname;
            if (check == null)
            {
                return View();
            }
            else
            {
                return View(check);
            }
        }
        [HttpPost]
        public IActionResult Index(int id, StockPiece sp)
        {
            var check = spm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            if (check == null)
            {
                StockPiece stockpiece = new StockPiece();
                stockpiece.ProductId = sp.ProductId;
                stockpiece.RemainingPiece = sp.RemainingPiece;
                stockpiece.SoldPiece = 0;
                stockpiece.CreatedDate = DateTime.Now;
                stockpiece.UpdatedDate = DateTime.Now;
                stockpiece.IsDeleted = false;
                spm.TAdd(stockpiece);
            }
            else
            {
                return RedirectToAction("UpdateStockDetail" , "StockDetail", new { id = id });
            }
            return RedirectToAction("Index", "MyProduct");
        }

        [HttpGet]
        public IActionResult UpdateStockDetail(int id)
        {
            var check = spm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            ViewBag.pid = id;
            if (check == null)
            {
                return View();
            }
            else
            {
                return View(check);
            }
        }
        [HttpPost]
        public IActionResult UpdateStockDetail(int id, StockPiece sa)
        {
            var check = spm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            if (check == null)
            {
                sa.SoldPiece = 0;
                sa.CreatedDate = DateTime.Now;
                sa.UpdatedDate = DateTime.Now;
                sa.IsDeleted = false;
                spm.TAdd(sa);
            }
            else
            {
                sa.Id = check.Id;
                sa.SoldPiece = check.SoldPiece;
                sa.CreatedDate = check.CreatedDate;
                sa.UpdatedDate = DateTime.Now;
                sa.IsDeleted = check.IsDeleted;
                spm.TUpdate(sa);
            }
            return RedirectToAction("Index", "MyProduct");
        }
    }
}
