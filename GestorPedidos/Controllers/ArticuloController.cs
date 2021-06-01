using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Servicios;

namespace GestorPedidos.Controllers
{
    public class ArticuloController : Controller
    {

        [HttpGet]
        public IActionResult Articulos()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NuevoArticulo()
        {
            return View();
        }
       /* [HttpPost]
        public IActionResult NuevoArticulo()
        {
            return View();
        }
       */
        [HttpGet]
        public IActionResult EditarArticulo()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult EditarArticulo()
        {
            return View();
        }

        */

    }
}
