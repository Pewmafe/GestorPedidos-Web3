using GestorPedidos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Newtonsoft.Json;
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
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            ViewData["Pedidos"] = this.pedidoServicio.ListarTodos();
            if (TempData["Entregados"] != null) ViewData["Pedidos"] = this.pedidoServicio.ListarPedidosEntregados();

            return View();
        }

        [HttpGet]
        public IActionResult ListarEntregados()
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            TempData["Entregados"] = true;
            return RedirectToAction("Pedido");
        }

        [HttpGet]
        public IActionResult NuevoPedido()
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            ViewData["Clientes"] = this.clienteServicio.listarClientesSinPedidosActivos();
            ViewData["Articulos"] = this.articuloServicio.ListarNoEliminados();

            return View();
        }
        [HttpPost]
        public IActionResult NuevoPedido(Pedido pedido, PedidoArticulo pedidoArticulo)
        {
            try
            {
                string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
                if (idUsuario == null)
                {
                    TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                    return RedirectToAction("Login", "Login");
                }
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Por favor complete el pedido con las validaciones correspondientes";
                    return RedirectToAction("NuevoPedido");
                }
                int idPedido = this.pedidoServicio.CrearPedido(pedido);
                pedidoArticulo.IdPedido = idPedido;
                this.pedidoServicio.CrearPedidoArticulo(pedidoArticulo);
                TempData["Success"] = "Pedido nro " + pedido.NroPedido + " agregado correctamente";
                return RedirectToAction("EditarPedido", new { id = idPedido });
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocurrio un error al generar el pedido, por favor intente de nuevo! \n " + e;
                return RedirectToAction("Pedido");
            }

        }
        [HttpGet]
        public IActionResult EditarPedido(int id)
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            Pedido pedido = this.pedidoServicio.ObtenerPorId(id);
            EditarPedidoViewModel editarPedidoViewModel = new() { Pedido = pedido };
            editarPedidoViewModel.ArticulosYCantidadesDelPedido = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(id);
            editarPedidoViewModel.ArticulosNoSeleccionados = this.pedidoServicio.listarArticulosNoSeleccionadosDeUnPedidoPorIdPedido(id);
            return View(editarPedidoViewModel);
        }

        public IActionResult BorrarArticuloDePedido(PedidoArticulo pedidoArticulo)
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            int idPedido2 = pedidoArticulo.IdPedido;
            this.pedidoServicio.EliminarArticuloAlPedido(pedidoArticulo);
            Dictionary<Articulo, int> carrito = this.pedidoServicio.listarArticulosConCantidadesDeUnPedidoPorPedidoId(idPedido2);
            return RedirectToAction("EditarPedido", new { id = idPedido2 });
        }

        [HttpPost]
        public IActionResult AgregarArticuloAUnPedido(PedidoArticulo pedidoArticulo)
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            int idPedido2 = pedidoArticulo.IdPedido;
            this.pedidoServicio.CrearPedidoArticulo(pedidoArticulo);
            return RedirectToAction("EditarPedido", new { id = idPedido2 });
        }

        [HttpPost]
        public IActionResult MarcarPedidoComoCerrado(int idPedido)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            this.pedidoServicio.MarcarPedidoComoCerrado(idPedido, idUsuario);
            Pedido pedido = this.pedidoServicio.ObtenerPorId(idPedido);
            TempData["Success"] = "Pedido numero " + pedido.NroPedido + " cerrado correctamente ";
            return RedirectToAction("Pedido");
        }

        [HttpPost]
        public IActionResult MarcarPedidoComoEntregado(int idPedido)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            this.pedidoServicio.MarcarPedidoComoEntregado(idPedido, idUsuario);
            Pedido pedido = this.pedidoServicio.ObtenerPorId(idPedido);
            TempData["Success"] = "Pedido numero " + pedido.NroPedido + " entregado correctamente ";
            return RedirectToAction("Pedido");
        }
    }
}
