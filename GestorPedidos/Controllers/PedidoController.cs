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
        private IItemService itemService;

        public PedidoController()
        {
            _20211CTPContext dbContext = new _20211CTPContext();
            this.itemService = new ItemService(dbContext);
        }
        [HttpGet]
        public IActionResult Pedido()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearPedido()
        {
            Usuario usuario = new Usuario();
            usuario.Apellido = "Fagliano";
            usuario.Nombre = "Santiago";
            usuario.Password = "1234";
            usuario.Email = "Santiago@email.com";
            usuario.EsAdmin = true;
            this.itemService.Created(usuario);

            return View();
        }
    }
}
