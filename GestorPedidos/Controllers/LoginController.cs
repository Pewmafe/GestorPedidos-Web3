﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorPedidos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int aux)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return Redirect("/Home/Index");
        }
    }
}
