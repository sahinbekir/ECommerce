using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ViewComponents.ProductComment
{
    public class ProductCommentList : ViewComponent
    {
        ProductCommentManager pcm = new ProductCommentManager(new EfProductCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = pcm.GetListByProduct(id);
            return View(values);
        }
    }
}
