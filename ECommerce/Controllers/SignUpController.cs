using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ECommerce.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SignUpController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            /*
            GenderManager gv = new GenderManager(new EfGenderRepository());
            List<SelectListItem> gendervalues = (from x in gv.GetListAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.gv = gendervalues;
            CityManager cm = new CityManager(new EfCityRepository());
            List<SelectListItem> cityvalues = (from x in cm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            ViewBag.cv = cityvalues;
             */
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.BornDate = model.BornDate;
                user.CityId = 1;
                user.VillageId = 1;
                user.Address = "";
                user.GenderId = 1;
                user.ImageUrl = "/Media/ecpp.png";
                user.RegisterDate = DateTime.Now;
                user.ProfileUpdatedDate = DateTime.Now;
                user.IsBlocked = false;
                user.IsDeleted = false;
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "SignInUser");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
