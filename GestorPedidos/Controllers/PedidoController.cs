using GestorPedidos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System;
using System.Collections.Generic;


namespace GestorPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoServicio pedidoServicio;
        private IUsuarioServicio usuarioServicio;
        private IClienteServicio clienteServicio;
        private IArticuloServicio articuloServicio;

        private _20211CTPContext dbContext;


        public PedidoController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.pedidoServicio = new PedidoServicio(dbContext);
            this.clienteServicio = new ClienteServicio(dbContext);
            this.usuarioServicio = new UsuarioServicio(dbContext);
            this.articuloServicio = new ArticuloServicio(dbContext);


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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                pedidoArticulo.IdPedido = this.pedidoServicio.CrearPedido(pedido);
                this.pedidoServicio.CrearPedidoArticulo(pedidoArticulo);
                return RedirectToAction("Pedido");
            }
            catch (Exception e)
            {
                return RedirectToAction("Pedido");
            }

        }
        [HttpGet]
        public IActionResult EditarPedido(int id)
        {
            Pedido pedido = this.pedidoServicio.ObtenerPorId(id);
            EditarPedidoViewModel editarPedidoViewModel = new() { Pedido = pedido };
            editarPedidoViewModel.ArticulosYCantidadesDelPedido = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(id);
            return View(editarPedidoViewModel);
        }

        /* public IActionResult BorrarArticuloDePedido(int idPedido, int idArticulo)
         {
             PedidoArticulo pedidoArticulo = this.pedidoServicio.BuscarPedidoArticuloPorIdPedidoYIdArticulo(idPedido, idArticulo);
             int idPedido2 = pedidoArticulo.IdPedido;
             this.pedidoServicio.EliminarArticuloAlPedido(pedidoArticulo);
             Dictionary<Articulo, int> carrito = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(idPedido2);
             return RedirectToAction("EditarPedido?idpedido=" + idPedido2);
         }*/
        public IActionResult BorrarArticuloDePedido(PedidoArticulo pedidoArticulo)
        {
            int idPedido2 = pedidoArticulo.IdPedido;
            this.pedidoServicio.EliminarArticuloAlPedido(pedidoArticulo);
            Dictionary<Articulo, int> carrito = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(idPedido2);
            return RedirectToAction("EditarPedido", new { id = idPedido2 });
        }
        [HttpGet]
        public IActionResult AgregarArticuloAlCarrito(int idArticulo)///TODO hacerlo sin ajax el agregar
        {
            this.pedidoServicio.AgregarArticuloAlCarritoPorIdArticulo(idArticulo);
            List<Articulo> carrito = this.pedidoServicio.DevolverCarrito();
            return Json(carrito);
            //return Json("");
        }

    }
}
