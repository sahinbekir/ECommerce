﻿using BusinessLayer.Concrete;
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
        StockAmountManager sam = new StockAmountManager(new EfStockAmountRepository());
        [HttpGet]
        public IActionResult AddStockDetail(int id)
        {
            var check = sam.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
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
        public IActionResult AddStockDetail(int id ,StockAmount sa)
        {
            var check = sam.GetListAll().Where(x=>x.ProductId==id).FirstOrDefault();
            if (check==null)
            {
                sa.SoldScore = 0;
                sa.CreatedDate = DateTime.Now;
                sa.UpdatedDate = DateTime.Now;
                sa.IsDeleted = false;
                sam.TAdd(sa);
            }
            else
            {
                sa.Id = check.Id;
                sa.SoldScore=check.SoldScore;
                sa.CreatedDate= check.CreatedDate;
                sa.UpdatedDate = DateTime.Now;
                sa.IsDeleted=check.IsDeleted;
                sam.TUpdate(sa);
            }
            return RedirectToAction("MyProduct","UserProduct");
        }

        public IActionResult Index(int page = 1)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductListWithCBU().Where(x=>x.UserId!=userid).ToPagedList(page, 8);
            return View(values);
        }
        public IActionResult Details(int id)
        {
            ViewBag.pid = id;
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductById(id).Where(x=>x.UserId!=userid);
            return View(values);
        }
        public IActionResult MyProductDetails(int id)
        {
            ViewBag.pid = id;
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductById(id).Where(x => x.UserId == userid);
            return View(values);
        }
        [HttpGet]
        public IActionResult MyProduct(int page = 1)
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = pm.GetProductListWithCBU().Where(x => x.UserId == userid).ToPagedList(page, 12);
            return View(values);
        }
        [HttpPost]
        public IActionResult MyProduct(AddProductViewModel p)
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            SubCategoryManager scm = new SubCategoryManager(new EfSubCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in scm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.scvalues = categoryvalues;
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
            if (p.ImageUrl != null)
            {
                var extension1 = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename1 = Guid.NewGuid() + extension1;
                var location1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/ProductImageFiles/", newimagename1);
                var stream1 = new FileStream(location1, FileMode.Create);
                p.ImageUrl.CopyTo(stream1);
                product.ImageUrl = "/Media/ProductImageFiles/" + newimagename1;

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
            product.SubCategoryId = p.SubCategoryId;
            product.Version = p.Version;
            product.Cost = p.Cost;

            product.UserId = userid;
            product.IsDeleted = false;
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            pm.TAdd(product);
            return RedirectToAction("MyProduct", "UserProduct");
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
            //return RedirectToAction("MyProduct","UserProduct");
            return View();
        }
        
    }
}
