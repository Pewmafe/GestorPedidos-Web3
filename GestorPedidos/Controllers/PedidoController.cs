using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;


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
            return View();
        }

        [HttpGet]
        public IActionResult NuevoPedido()
        {
            ViewData["Clientes"] = this.clienteServicio.ListarNoEliminados();
            ViewData["Articulos"] = this.articuloServicio.ListarNoEliminados();
            return View();
        }

        [HttpGet]
        public IActionResult EditarPedido()
        {

            return View();

        }
    }
}
