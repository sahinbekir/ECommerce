using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ECommerce.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AddProductViewModel p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            Product product = new Product();
            if (p.ImageUrl != null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                product.ImageUrl = newimagename;

            }
            if (p.ThumbnailImgUrl != null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                product.ThumbnailImgUrl = newimagename;

            }
            if (p.MovieUrl != null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductMovieFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                product.MovieUrl = newimagename;

            }
            product.Name = p.Name;
            product.Description = p.Description;
            product.BrandId = p.BrandId;
            product.SubCategoryId = p.SubCategoryId;
            product.Version = p.Version;
            product.Cost = p.Cost;

            product.UserId = userid;
            product.IsDeleted = false;
            product.CreatedDate = Convert.ToDateTime(DateTime.Now);
            product.UpdatedDate = Convert.ToDateTime(DateTime.Now);
            pm.TAdd(product);
            return RedirectToAction("Index", "Product");
        }
    }
}
