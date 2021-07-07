using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (clientes.Count != 0)
            {
                clientesDTO = clienteServicio.mapearListaClienteAListaClienteDTO(clientes);
            }
             

            return Ok(new
            {
                Count= clientesDTO.Count,
                Items= clientesDTO
            });
        }
    }
}
