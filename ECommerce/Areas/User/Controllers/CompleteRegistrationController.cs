using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ECommerce.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class CompleteRegistrationController : Controller
    {
        UserManager _userManager = new UserManager(new EfUserRepository());
        [HttpGet]
        public IActionResult Index()
        {
            CityManager cm = new CityManager(new EfCityRepository());
            List<SelectListItem> cityvalues = (from x in cm.GetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.cv = cityvalues;

            VillageManager vm = new VillageManager(new EfVillageRepository());
            List<SelectListItem> villagevalues = (from x in vm.GetListAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.vv = villagevalues;

            GenderManager gv = new GenderManager(new EfGenderRepository());
            List<SelectListItem> gendervalues = (from x in gv.GetListAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.gv = gendervalues;
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var user = _userManager.GetListAll().Where(x => x.UserName == username).FirstOrDefault();
                user.CityId = model.CityId;
                user.VillageId = model.VillageId;
                user.Address = model.Address;
                user.GenderId = model.GenderId;
                user.ProfileUpdatedDate = DateTime.Now;

                _userManager.TUpdate(user);
                return RedirectToAction("ProfilePhotoUpload", "CompleteRegistration");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult ProfilePhotoUpload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProfilePhotoUpload(ProfilePhotoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var user = _userManager.GetListAll().Where(x => x.UserName == username).FirstOrDefault();
                if (model.ProfilePhoto != null)
                {
                    var extension = Path.GetExtension(model.ProfilePhoto.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Media/UserImageFiles/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    model.ProfilePhoto.CopyTo(stream);
                    user.ImageUrl = "/Media/ImageFiles/" + newimagename;

                    user.Address = model.Address;
                    user.ProfileUpdatedDate = DateTime.Now;
                    _userManager.TUpdate(user);
                    return RedirectToAction("Index", "UserProduct");
                }
                else
                {
                    user.Address = model.Address;
                    user.ProfileUpdatedDate = DateTime.Now;
                    _userManager.TUpdate(user);
                    return RedirectToAction("Index", "UserProduct");
                }
            }
            return View(model);
        }
    }
}
