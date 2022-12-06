using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            var values = nm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotification(Notification model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            model.IsDeleted = false;
            nm.TAdd(model);
            return RedirectToAction("Index", "Notification");
        }
        [HttpGet]
        public IActionResult UpdateNotification(int id)
        {
            var values = nm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateNotification(Notification model)
        {
            model.UpdatedDate = DateTime.Now;
            nm.TUpdate(model);
            return RedirectToAction("Index", "Notification");
        }
        public IActionResult DeleteNotification(int id)
        {

            var value = nm.GetById(id);
            if (value.IsDeleted == true)
            {
                value.IsDeleted = false;
            }
            else
            {
                value.IsDeleted = true;
            }
            value.UpdatedDate = DateTime.Now;
            nm.TUpdate(value);
            return RedirectToAction("Index", "Notification");
        }
    }
}