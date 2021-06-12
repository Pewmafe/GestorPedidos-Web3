using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class PedidoController : Controller
    {
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
