using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class ProductCommentController : Controller
    {
        ProductCommentManager pcm = new ProductCommentManager(new EfProductCommentRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult MyProductComments()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var myp = pm.GetListAll().Where(x => x.UserId == userid).ToList();
            var pcom = pcm.GetListAll().ToList();
            List<ProductComment> values = new List<ProductComment>();
            foreach (var item in myp)
            {
                foreach (var item2 in pcom)
                {
                    if (item.Id == item2.ProductId)
                    {
                        values.Add(item2);
                    }
                }
            }
            
            return View(values);
        }
        public IActionResult MyComments()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pcm.GetListAll().Where(x => x.UserId == userid).ToList();
            return View(values);
        }
        public IActionResult DeleteMyProductComments(int id)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var myp = pm.GetListAll().Where(x=>x.UserId==userid).ToList();
            var checkcomment = pcm.GetById(id);
            var checkstatus = false;
            foreach (var item in myp)
            {
                if (item.Id==checkcomment.ProductId)
                {
                    checkstatus = true;
                    break;
                }
            }
            if (checkstatus==true)
            {
                pcm.TDelete(checkcomment);
            }
            return RedirectToAction("MyProductComments", "ProductComment");
        }
        public IActionResult DeleteMyComments(int id)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y=>y.Id).FirstOrDefault();
            var value = pcm.GetListAll().Where(x=>x.UserId==userid && x.Id==id).FirstOrDefault();
            pcm.TDelete(value);
            return RedirectToAction("MyComments", "ProductComment");
        }
        [HttpGet]
        public PartialViewResult AddProductComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddProductComment(ProductComment p)
        {
            var username = User.Identity.Name;
            var user = um.GetListAll().Where(x => x.UserName == username).FirstOrDefault();
            p.CreatedDate = DateTime.Now;
            p.UpdatedDate = DateTime.Now;
            p.IsDeleted = false;
            p.UserId = user.Id;
            p.UserFullName=user.FullName;
            p.UserName = user.UserName;
            p.UserImage = user.ImageUrl;
            var cururl = "https://localhost:3000/User/UserProduct/Details/";
            var urlid = p.ProductId;
            pcm.TAdd(p);
            return Redirect(cururl + urlid);
        }
    }
}
