﻿using Microsoft.AspNetCore.Mvc;

namespace ASSESSMENTAPI.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
