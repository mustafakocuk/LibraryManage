﻿using Microsoft.AspNetCore.Mvc;

namespace booklib.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
