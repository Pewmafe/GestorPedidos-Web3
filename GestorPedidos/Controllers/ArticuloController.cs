using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Service;

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
      /*  [HttpPost]
        public IActionResult NuevoArticulo(Articulo articulo)
        {
            if(!ModelState.IsValid)
            {
                return View(articulo);
            }

            return View();
        }*/
       
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
        [HttpGet]
        public IActionResult VerArticulo()
        {
            //meter temp data
            return View();
        }
        [HttpGet]
        public IActionResult FiltrarArticulo()
        {
            //meter temp data
            return RedirectToAction("Articulos");
        }
    }
}
