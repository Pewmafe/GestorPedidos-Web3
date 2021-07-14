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
using Models.DTO;
using Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private _20211CTPContext _context;
        private IPedidoServicio _servicioPedido;
      


        public PedidoController(_20211CTPContext context)
        {
            _context = context;
            _servicioPedido = new PedidoServicio(_context);
            

        }

        [HttpPost]
        [Route("buscar")]
        //[Authorize]
        public ActionResult<object> Buscar([FromBody] BodyPostPedido pedido)
        {

            List<Pedido> pedidosDeUnCliente = _servicioPedido.ListarPedidosDeUnCliente(pedido.IdCliente, pedido.IdEstado);
            
            List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            

            if (pedidosDeUnCliente.Count != 0)
            {
                pedidosDTO = _servicioPedido.mapearListaPedidoAListaPedido(pedidosDeUnCliente);
            }


            return Ok(new
            {
                Count = pedidosDTO.Count,
                Items = pedidosDTO

            });


        }

        [HttpPost]
        [Route("guardar")]
        //[Authorize]
        public ActionResult<object> Guardar([FromBody] BodyPostGuardarPedido pedido)
        {
            Pedido pedidoAPI = new Pedido();

            pedidoAPI.IdCliente = pedido.IdCliente; 

            int IdPedido = _servicioPedido.CrearPedido(pedidoAPI);

            pedido.pedidosArticulos.ForEach(a =>
            {
                a.IdPedido = IdPedido;

                _servicioPedido.CrearPedidoArticulo(a);

            });

         

            //foreach (PedidoArticulo item in pedido.PedidoArticulos)
            //{
            //    if(item.IdPedido == pedido.IdPedido)

            //    _servicioPedido.CrearPedidoArticulo(item);
            //}

  
            return Ok(new
            {
                Mensaje = "Pedido " + IdPedido + " guardado con éxito"


            });



        }
    }

}
