﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
