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

        public IActionResult Clientes()
        {
            
            return View();
        }

        public IActionResult NuevoCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuevoCliente(Cliente client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            return RedirectToAction("Clientes");
        }

        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
