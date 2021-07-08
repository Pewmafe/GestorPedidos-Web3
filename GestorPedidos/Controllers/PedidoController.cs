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
            ViewData["Clientes"] = this.clienteServicio.ListarNoEliminados();
            ViewData["Articulos"] = this.articuloServicio.ListarNoEliminados();

            return View();
        }
        [HttpPost]
        public IActionResult NuevoPedido(Pedido pedido, PedidoArticulo pedidoArticulo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Por favor complete el pedido con las validaciones correspondientes";
                    return View();
                }
                int idPedido = this.pedidoServicio.CrearPedido(pedido);
                pedidoArticulo.IdPedido = idPedido;
                this.pedidoServicio.CrearPedidoArticulo(pedidoArticulo);
                TempData["Success"] = "Pedido nro " + pedido.NroPedido + " agregado correctamente";
                return RedirectToAction("EditarPedido", new { id = idPedido });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocurrio un error al generar el pedido, por favor intente de nuevo!";
                return RedirectToAction("Pedido");
            }

        }
        [HttpGet]
        public IActionResult EditarPedido(int id)
        {
            Pedido pedido = this.pedidoServicio.ObtenerPorId(id);
            EditarPedidoViewModel editarPedidoViewModel = new() { Pedido = pedido };
            editarPedidoViewModel.ArticulosYCantidadesDelPedido = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(id);
            editarPedidoViewModel.ArticulosNoSeleccionados = this.pedidoServicio.listarArticulosNoSeleccionadosDeUnPedidoPorIdPedido(id);
            return View(editarPedidoViewModel);
        }

        public IActionResult BorrarArticuloDePedido(PedidoArticulo pedidoArticulo)
        {
            int idPedido2 = pedidoArticulo.IdPedido;
            this.pedidoServicio.EliminarArticuloAlPedido(pedidoArticulo);
            Dictionary<Articulo, int> carrito = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(idPedido2);
            return RedirectToAction("EditarPedido", new { id = idPedido2 });
        }

        [HttpPost]
        public IActionResult AgregarArticuloAUnPedido(PedidoArticulo pedidoArticulo)
        {
            int idPedido2 = pedidoArticulo.IdPedido;
            this.pedidoServicio.CrearPedidoArticulo(pedidoArticulo);
            return RedirectToAction("EditarPedido", new { id = idPedido2 });
        }
    }
}
