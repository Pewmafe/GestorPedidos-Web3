using api.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Models;
using Service;
using System;
using Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private _20211CTPContext _context;
        private IPedidoServicio _servicioPedido;
        IClienteServicio _servicioCliente;


        public PedidoController(_20211CTPContext context)
        {
            _context = context;
            _servicioPedido = new PedidoServicio(_context);
            _servicioCliente = new ClienteServicio(_context);

        }

        [HttpPost]
        [Route("buscar")]
        //[Authorize]
        public ActionResult<object> Buscar(Pedido pedido)
        {

            pedido = _servicioPedido.ObtenerPorId(pedido.IdPedido);


            return Ok(new
            {
                IdPedido = pedido.IdPedido,
                IdCliente = pedido.IdCliente,
                Estado = pedido.IdEstado,
                FechaModificacion = pedido.FechaModificacion,
                ModificadoPor = pedido.ModificadoPor,


            });


        }

        [HttpPost]
        [Route("guardar")]
        //[Authorize]
        public ActionResult<object> Guardar(PedidoArticulo pedidoArticulo)
        {

            _servicioPedido.CrearPedidoArticulo(pedidoArticulo);
            

            return Ok(new
            {
                Mensaje = "Pedido " + pedidoArticulo.IdPedido + " guardado con éxito"


            });



        }
    }

}
