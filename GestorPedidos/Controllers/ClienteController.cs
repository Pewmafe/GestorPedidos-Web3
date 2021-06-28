using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteServicio clienteServicio;
        private _20211CTPContext dbContext;

        public ClienteController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.clienteServicio = new ClienteServicio(dbContext);
        }

        [HttpGet]
        public IActionResult Clientes()
        {
            List<Cliente> clientes = clienteServicio.ListarNoEliminados();
            return View(clientes);
        }

        public IActionResult NuevoCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuevoCliente(Cliente cliente, string guardar)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            clienteServicio.Crear(cliente);

            if (guardar.ToLower().Equals("guardar"))
            {
                return RedirectToAction("Clientes");
            }
            return RedirectToAction("NuevoCliente");
        }


        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
