using ECommerce.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(SignUpViewModel p)
        {
            if (ModelState.IsValid)
            {

                AppUser user = new AppUser();
                if (p.ImageUrl != null)
                {
                    //user.ImageUrl = "Loop"; Dont come here...???
                    var extension = Path.GetExtension(p.ImageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/UserImageFiles/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    p.ImageUrl.CopyTo(stream);
                    user.ImageUrl = newimagename;

                }
                user.Email = p.Email;
                user.UserName = p.UserName;
                user.FullName = p.FullName;
                user.PhoneNumber = p.PhoneNumber;
                user.BornDate = p.BornDate;
                user.CityId = p.CityId;
                user.Village = p.Village;
                user.Address = p.Address;
                user.RegisterDate = DateTime.Now;

                var result = await _userManager.CreateAsync(user, p.Password);
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

            return View(p);
        }
    }
}
