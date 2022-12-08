﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ShoppingCartController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        ProductManager pm = new ProductManager(new EfProductRepository());
        ShoppingCartManager scartm = new ShoppingCartManager(new EfShoppingCartRepository());
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = scartm.GetListAll().Where(x => x.UserId == userid && x.IsDeleted == false).ToList();
            return View(values);
        }
        public IActionResult AddMyShoppingCart(int id)
        {
            
            var username = User.Identity.Name;
            var userid = um.GetListAll().Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var check = scartm.GetListAll().Where(x => x.ProductId == id).FirstOrDefault();
            var productcost = pm.GetById(id);
            if (check == null)
            {
                
                ShoppingCart scart = new ShoppingCart();
                scart.ProductId = id;
                scart.UserId = userid;
                scart.Cost = productcost.Cost;
                scart.CreatedDate = DateTime.Now;
                scart.UpdatedDate = DateTime.Now;
                scart.IsDeleted = false;
                scartm.TAdd(scart);
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
                check.Cost = productcost.Cost;
                scartm.TUpdate(check);
            }

            //del product cart
            ProductCartManager pcartm = new ProductCartManager(new EfProductCartRepository());
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


            return RedirectToAction("Index", "ShoppingCart");
        }
        public IActionResult HideMyShoppingCart(int id)
        {
            var curscart = scartm.GetById(id);


            curscart.UpdatedDate = DateTime.Now;
            if (curscart.IsDeleted == false)
            {
                curscart.IsDeleted = true;
            }
            else
            {
                curscart.IsDeleted = true;
            }
            scartm.TUpdate(curscart);

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
