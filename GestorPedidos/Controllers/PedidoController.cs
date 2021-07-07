using GestorPedidos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System.Collections.Generic;


namespace GestorPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoServicio pedidoServicio;
        private IUsuarioServicio usuarioServicio;
        private IClienteServicio clienteServicio;
        private IArticuloServicio articuloServicio;
        private IPedidoArticuloServicio pedidoarticuloServicio;
        private _20211CTPContext dbContext;


        public PedidoController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.pedidoServicio = new PedidoServicio(dbContext);
            this.clienteServicio = new ClienteServicio(dbContext);
            this.usuarioServicio = new UsuarioServicio(dbContext);
            this.articuloServicio = new ArticuloServicio(dbContext);
            this.pedidoarticuloServicio = new PedidoArticuloServicio(dbContext);

        }
        [HttpGet]
        public IActionResult Pedido()
        {
            ViewData["Pedidos"] = this.pedidoServicio.ListarTodos();
            return View();
        }

        [HttpGet]
        public IActionResult NuevoPedido()
        {
            this.pedidoServicio.VaciarCarrito();
            ViewData["Clientes"] = this.clienteServicio.ListarNoEliminados();
            ViewData["Articulos"] = this.articuloServicio.ListarNoEliminados();
            ViewData["Carrito"] = this.pedidoServicio.DevolverCarrito();
            return View();
        }
        [HttpPost]
        public IActionResult NuevoPedido(Pedido pedido, PedidoArticulo pedidoArticulo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            pedidoArticulo.IdPedido = this.pedidoServicio.CrearPedido(pedido);
            this.pedidoarticuloServicio.Crear(pedidoArticulo, 0);
            return RedirectToAction("Pedido");
        }
        [HttpGet]
        public IActionResult EditarPedido()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AgregarArticuloAlCarrito(int idArticulo)
        {
            this.pedidoServicio.AgregarArticuloAlCarritoPorIdArticulo(idArticulo);
            List<Articulo> carrito = this.pedidoServicio.DevolverCarrito();
            return Json(carrito);
            //return Json("");
        }

    }
}
