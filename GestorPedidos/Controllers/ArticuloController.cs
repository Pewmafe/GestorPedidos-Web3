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
        public IActionResult Articulos(string codigo,string descripcion,string noEliminados)
        {
            
            List<Articulo> articulos = articuloServicio.ListarTodos();

            return View(articulos);
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
        public IActionResult EditarArticulo(int IdArticulo)
        {
            Articulo articulo = articuloServicio.ObtenerPorId(IdArticulo);

            return View(articulo);
        }

        [HttpPost]
        public IActionResult EditarArticulo(Articulo articulo)
        {

            if (!ModelState.IsValid)
            {
                return View(articulo);
            }

            articuloServicio.Modificar(articulo);

            return RedirectToAction(nameof(Articulos));
        }

      
        [HttpGet]
        public IActionResult VerArticulo(int IdArticulo)
        {
            Articulo articulo = articuloServicio.ObtenerPorId(IdArticulo);

            return View(articulo);
           
        }
        [HttpGet]
        public IActionResult EliminarArticulo(int IdArticulo)
        {
            Articulo articulo = articuloServicio.ObtenerPorId(IdArticulo);
            articuloServicio.Borrar(articulo);

            return RedirectToAction(nameof(Articulos));
        }


    }
}
