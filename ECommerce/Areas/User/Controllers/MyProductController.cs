using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ECommerce.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using X.PagedList;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class MyProductController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        ProductRatingManager prm = new ProductRatingManager(new EfProductRatingRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        StockPieceManager sam = new StockPieceManager(new EfStockPieceRepository());
        public IActionResult Index(int page = 1)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductListWithCBU().Where(x => x.UserId == userid).ToPagedList(page, 12);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            ViewBag.pid = id;
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductById(id).Where(x => x.UserId == userid);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.cvalues = categoryvalues;
            SubCategoryManager scm = new SubCategoryManager(new EfSubCategoryRepository());
            List<SelectListItem> subcategoryvalues = (from x in scm.GetListAll()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.Id.ToString()
                                                      }).ToList();
            ViewBag.scvalues = subcategoryvalues;
            BrandManager bm = new BrandManager(new EfBrandRepository());
            List<SelectListItem> brandvalues = (from x in bm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.bvalues = brandvalues;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            Product product = new Product();
            if (p.ImageUrl1 != null)
            {
                var extension1 = Path.GetExtension(p.ImageUrl1.FileName);
                var newimagename1 = Guid.NewGuid() + extension1;
                var location1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename1);
                var stream1 = new FileStream(location1, FileMode.Create);
                p.ImageUrl1.CopyTo(stream1);
                product.ImageUrl1 = "/Media/ProductImageFiles/" + newimagename1;

            }
            if (p.ImageUrl2 != null)
            {
                var extension4 = Path.GetExtension(p.ImageUrl2.FileName);
                var newimagename4 = Guid.NewGuid() + extension4;
                var location4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename4);
                var stream4 = new FileStream(location4, FileMode.Create);
                p.ImageUrl2.CopyTo(stream4);
                product.ImageUrl2 = "/Media/ProductImageFiles/" + newimagename4;

            }
            if (p.ThumbnailImgUrl != null)
            {
                var extension2 = Path.GetExtension(p.ThumbnailImgUrl.FileName);
                var newimagename2 = Guid.NewGuid() + extension2;
                var location2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename2);
                var stream3 = new FileStream(location2, FileMode.Create);
                p.ThumbnailImgUrl.CopyTo(stream3);
                product.ThumbnailImgUrl = "/Media/ProductImageFiles/" + newimagename2;

            }
            if (p.MovieUrl != null)
            {
                var extension3 = Path.GetExtension(p.MovieUrl.FileName);
                var newimagename3 = Guid.NewGuid() + extension3;
                var location3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductMovieFiles/", newimagename3);
                var stream3 = new FileStream(location3, FileMode.Create);
                p.MovieUrl.CopyTo(stream3);
                product.MovieUrl = "/Media/ProductMovieFiles/" + newimagename3;

            }
            product.Name = p.Name;
            product.Description = p.Description;
            product.BrandId = p.BrandId;
            product.CategoryId = p.CategoryId;
            product.SubCategoryId = p.SubCategoryId;
            product.Version = p.Version;
            product.Cost = p.Cost;

            product.UserId = userid;
            product.IsDeleted = false;
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            pm.TAdd(product);
            var proid = pm.GetListAll().Where(x => x.UserId == userid && x.Name == product.Name).Select(y => y.Id).FirstOrDefault();
            ProductRating prorat = new ProductRating();
            prorat.ProductId = proid;
            prorat.TotalScore = 0;
            prorat.RatingCount = 0;
            prorat.CreatedDate = DateTime.Now;
            prorat.UpdatedDate = DateTime.Now;
            prorat.IsDeleted = false;
            prm.TAdd(prorat);

            var npid = pm.GetListAll().Where(x => x.UserId == userid && x.Name == p.Name).Select(y => y.Id).FirstOrDefault();
            return RedirectToAction("Index", "StockDetail", new { id = npid });
        }
        [HttpGet]
        public IActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(AddProductViewModel p)
        {

            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            var productvalue = pm.GetById(id);
            pm.TDelete(productvalue);
            return RedirectToAction("Index", "MyProduct");
        }
    }
}
