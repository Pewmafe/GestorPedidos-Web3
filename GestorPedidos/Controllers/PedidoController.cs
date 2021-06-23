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
        private IUsuarioServicio usuarioServicio;
        private _20211CTPContext dbContext;

        public PedidoController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.pedidoServicio = new PedidoServicio(dbContext);
            this.usuarioServicio = new UsuarioServicio(dbContext);
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
            usuario.Apellido = "sanches";
            usuario.Nombre = "matias";
            usuario.Password = "1234";
            usuario.Email = "Santiago@email.com";
            usuario.EsAdmin = true;
            usuarioServicio.Crear(usuario);

            return View();
        }
    }
}
