using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorPedidos.Controllers
{
    public class ClienteController : Controller
    {

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
