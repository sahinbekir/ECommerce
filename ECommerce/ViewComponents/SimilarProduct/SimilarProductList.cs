using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ViewComponents.SimilarProduct
{
    public class SimilarProductList : ViewComponent
    {
        ProductManager spm = new ProductManager(new EfProductRepository());
        public IViewComponentResult Invoke(int id)
        {
            var same = spm.GetById(id);
            var scid = (int)same.SubCategoryId;
            var similars = spm.GetProductListWithCBU().Where(x => x.SubCategoryId == scid).Take(4).ToList();
            return View(similars);
        }
    }
}
