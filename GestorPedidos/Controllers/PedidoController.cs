using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoServicio pedidoServicio;

        public PedidoController()
        {
            _20211CTPContext dbContext = new _20211CTPContext();
            this.pedidoServicio = new PedidoServicio(dbContext);
        }
        [HttpGet]
        public IActionResult Pedido()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearPedido()
        {
          

            return View();
        }
    }
}
