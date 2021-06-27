using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Service;
using Newtonsoft.Json;

namespace GestorPedidos.Controllers
{
    public class ArticuloController : Controller
    {
        private IArticuloServicio articuloServicio; 
        private _20211CTPContext dbContext;

        public ArticuloController(_20211CTPContext ctx)
        {
            dbContext = ctx;
            articuloServicio = new ArticuloServicio(dbContext);
        }

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
        [HttpPost]
        public IActionResult NuevoArticulo(Articulo articulo, string guardar)
        {
            if (!ModelState.IsValid)
            {
                return View(articulo);
            }

            articuloServicio.Crear(articulo);
            TempData["art"] = JsonConvert.SerializeObject(articulo);

            if (guardar != null && guardar.ToLower().Equals("guardar"))
            {
                return RedirectToAction(nameof(Articulos));
            }

            return RedirectToAction(nameof(NuevoArticulo));
        }
       
        [HttpGet]
        public IActionResult EditarArticulo(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditarArticulo(Articulo articulo)
        {
            return View();
        }

      
        [HttpGet]
        public IActionResult VerArticulo(int id)
        {
            
            return View();
        }
       
    }
}
