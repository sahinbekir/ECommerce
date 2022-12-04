using ECommerce.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class SignInUserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public SignInUserController(SignInManager<AppUser> signInManager)
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
                    
                        return RedirectToAction("Index", "UserDashboard");
                    
                }
                else
                {
                    return RedirectToAction("Index", "SignInUser");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "SignInUser");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
