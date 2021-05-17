using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            
            return View();
        }

        public IActionResult NuevoCliente()
        {
            return View();
        }

        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
