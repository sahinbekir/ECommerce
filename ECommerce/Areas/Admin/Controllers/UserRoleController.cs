using ECommerce.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public UserRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                id = values.Id,
                name = values.Name,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values = _roleManager.Roles.Where(x => x.Id == model.id).FirstOrDefault();
            values.Name = model.name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id;
            var userroles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.roleid = item.Id;
                m.name = item.Name;
                m.exists = userroles.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.exists)
                {
                    await _userManager.AddToRoleAsync(user, item.name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
        
    }
}
