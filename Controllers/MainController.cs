﻿using Microsoft.AspNetCore.Mvc;

namespace CheckersProject.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
