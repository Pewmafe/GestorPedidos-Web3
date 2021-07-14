using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Service;
using Models.Models;
using Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IArticuloServicio articuloServicio;
        private _20211CTPContext context;

        public ProductsController(_20211CTPContext ctx)
        {
            this.context = ctx;
            this.articuloServicio = new ArticuloServicio(ctx);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<object> GetAll()
        {
            List<Articulo> productos = articuloServicio.ListarTodos();
            List<ArticuloDTO> productosDTO = new List<ArticuloDTO>();

            if (productos.Count == 0)
            {
                return Ok(new
                {
                    msg = "No hay articulos que mostrar."
                });
            }

            productosDTO = articuloServicio.mapearListaArticuloAListaArticuloDTO(productos);
            
            return Ok(new
            {
                Count = productosDTO.Count,
                Items = productosDTO
            });
        }

        [HttpPost]
        [Route("filtrar")]
        [Authorize]
        public ActionResult<object> GetAllByFilter([FromBody] BodyPost Filtro)
        {
            List<Articulo> productos = articuloServicio.ListarPorFiltro(Filtro.Filtro);
            List<ArticuloDTO> productosDTO = new List<ArticuloDTO>();
            if (productos.Count == 0)
            {
                return Ok(new
                {
                    msg = "No hay articulos que mostrar."
                });
            }

            productosDTO = articuloServicio.mapearListaArticuloAListaArticuloDTO(productos);

            return Ok(new
            {
                Count = productosDTO.Count,
                Items = productosDTO
            });
        }
    }
}
