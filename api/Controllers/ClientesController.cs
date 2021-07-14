using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Models;
using Service;
using System.Collections.Generic;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private IClienteServicio clienteServicio;
        private _20211CTPContext dbContext;

        public ClientesController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.clienteServicio = new ClienteServicio(dbContext);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<object> GetAll()
        {
            List<Cliente> clientes = clienteServicio.ListarTodos();
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            if (clientes.Count == 0)
            {
                return Ok(new
                {
                    msg = "No hay clientes que mostrar."
                });
            }

            clientesDTO = clienteServicio.mapearListaClienteAListaClienteDTO(clientes);

            return Ok(new
            {
                Count= clientesDTO.Count,
                Items= clientesDTO
            });
        }

        [HttpPost]
        [Route("filtrar")]
        [Authorize]
        public ActionResult<object> GetAllByFilter([FromBody] BodyPost Filtro)
        {
            List<Cliente> clientes = clienteServicio.ListarPorFiltro(Filtro.Filtro);
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            if (clientes.Count == 0)
            {
                return Ok(new
                {
                    msg = "No hay clientes que mostrar."
                });
            }

            clientesDTO = clienteServicio.mapearListaClienteAListaClienteDTO(clientes);

            return Ok(new
            {
                Count = clientesDTO.Count,
                Items = clientesDTO
            });
        }
    }
}
