using ECommerce.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class SignInAdminController : Controller
    {
        
        private readonly SignInManager<AppUser> _signInManager;
        public SignInAdminController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "AdminDashboard");

                }
                else
                {
                    return RedirectToAction("Index", "SignInAdmin");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "SignInAdmin");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
