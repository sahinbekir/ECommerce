using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ViewComponents.ProductStock
{
    public class ProductStockInfo : ViewComponent
    {
        StockPieceManager spm = new StockPieceManager(new EfStockPieceRepository());
        public IViewComponentResult Invoke(int id)
        {
            var value = spm.GetListAll().Where(x=>x.ProductId==id).ToList();
            return View(value);
        }
    }
}
