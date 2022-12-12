using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProductCartController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductCartManager pcartm = new ProductCartManager(new EfProductCartRepository());

        NewsProductManager npm = new NewsProductManager(new EfNewsProductRepository());
        public IActionResult AddNewsProduct(int id)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var check = npm.GetListAll().Where(x => x.ProductId == id && x.UserId==userid).FirstOrDefault();
            if (check == null)
            {
                NewsProduct np = new NewsProduct();
                np.ProductId = id;
                np.UserId = userid;
                np.CreatedDate = DateTime.Now;
                np.UpdatedDate = DateTime.Now;
                np.IsDeleted = false;
                npm.TAdd(np);
            }
            else
            {

                check.UpdatedDate = DateTime.Now;
                if (check.IsDeleted == false)
                {
                    check.IsDeleted = false;
                }
                else
                {
                    check.IsDeleted = false;
                }
                npm.TUpdate(check);
            }
            return RedirectToAction("Index", "ProductCart");
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pcartm.GetListAll().Where(x=>x.UserId==userid && x.IsDeleted==false).ToList();
            return View(values);
        }
        public IActionResult AddMyProductCart(int id)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var check = pcartm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            
                ProductCart pcart = new ProductCart();
                pcart.ProductId = id;
                pcart.UserId = userid;
                pcart.CreatedDate = DateTime.Now;
                pcart.UpdatedDate = DateTime.Now;
                pcart.IsDeleted = false;
                pcartm.TAdd(pcart);
            
            return RedirectToAction("Index", "ProductCart");
        }
        public IActionResult DeleteMyProductCart(int id)
        {
            var curpcart = pcartm.GetById(id);


            curpcart.UpdatedDate = DateTime.Now;
                if (curpcart.IsDeleted == false)
                {
                curpcart.IsDeleted = true;
                }
                else
                {
                curpcart.IsDeleted = true;
                }
                pcartm.TUpdate(curpcart);
            
            return RedirectToAction("Index", "ProductCart");
        }
    }
}