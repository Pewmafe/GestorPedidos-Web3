using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class ArticuloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Articulos()
        {
            return View();
        }

        public IActionResult NuevoArticulo()
        {
            return View();
        }


        public IActionResult EditarArticulo()
        {
            return View();
        }

        public IActionResult VerArticulo()
        {
            return View();
        }



    }
}
