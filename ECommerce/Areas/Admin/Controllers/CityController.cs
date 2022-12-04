﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        //add list del update
        public IActionResult Index()
        {
            return View();
        }
    }
}