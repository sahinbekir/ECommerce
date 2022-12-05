using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using City = EntityLayer.Concrete.City;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class ModeratorController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public ModeratorController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        CityManager cm = new CityManager(new EfCityRepository());
        VillageManager vm = new VillageManager(new EfVillageRepository());
        GenderManager gm = new GenderManager(new EfGenderRepository());
        Context context = new Context();
        //UserManager userm = new UserManager(new EfUserRepository());
        public async Task<IActionResult> Index()
        {
            /*
             var useradmin = userm.GetListAll().Where(x=>x.UserName=="admin").FirstOrDefault();
            await _userManager.AddToRoleAsync(useradmin, "Admin");
            var userbuyerseller = userm.GetListAll().Where(x => x.UserName == "user").FirstOrDefault();
            await _userManager.AddToRoleAsync(userbuyerseller, "User");
             */
            return View();
        }
        public async Task<IActionResult> AddModerator()
        {
            var verify = context.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }

            var c = new City() { Name = "Adana" };
            cm.TAdd(c);
            var v = new Village { CityId = 1, Name = "Aladağ" };
            vm.TAdd(v);
            var g1 = new Gender { Name = "Male", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g1);
            var g2 = new Gender { Name = "Female", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g2);
            var g3 = new Gender { Name = "Other", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g3);
            AppRole role1 = new AppRole
            {
                Name = "Admin"
            };
            var result = await _roleManager.CreateAsync(role1);
            AppRole role2 = new AppRole
            {
                Name = "User"
            };
            var result2 = await _roleManager.CreateAsync(role2);

            AppUser admin = new AppUser();
            admin.Email = "admin@ec.io";
            admin.UserName = "admin";
            admin.FullName = "Admin Admin";
            admin.PhoneNumber = "5311313071";
            admin.BornDate = DateTime.Now;
            admin.CityId = 1;
            admin.VillageId = 1;
            admin.Address = "";
            admin.GenderId = 1;
            admin.ImageUrl = "/Media/ecpp.png";
            admin.RegisterDate = DateTime.Now;
            admin.ProfileUpdatedDate = DateTime.Now;
            admin.IsBlocked = false;
            admin.IsDeleted = false;
            var Password1 = "Aa.12345";
            var result3 = await _userManager.CreateAsync(admin, Password1);

            AppUser user = new AppUser();
            user.Email = "user@ec.io";
            user.UserName = "user";
            user.FullName = "User User";
            user.PhoneNumber = "2711378654";
            user.BornDate = DateTime.Now;
            user.CityId = 1;
            user.VillageId = 1;
            user.Address = "";
            user.GenderId = 1;
            user.ImageUrl = "/Media/ecpp.png";
            user.RegisterDate = DateTime.Now;
            user.ProfileUpdatedDate = DateTime.Now;
            user.IsBlocked = false;
            user.IsDeleted = false;
            var Password2 = "Aa.12345";
            var result4 = await _userManager.CreateAsync(user, Password2);



            return RedirectToAction("Index", "Moderator");
        }
    }
}
