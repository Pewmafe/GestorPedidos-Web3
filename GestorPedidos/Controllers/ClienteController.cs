using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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
           string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
           List <Cliente> clientes = clienteServicio.ListarTodos();
            return View(clientes);
        }

        public IActionResult NuevoCliente()
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
           
            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult NuevoCliente(Cliente cliente, string guardar)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.Crear(cliente, idUsuario);

            if (guardar.ToLower().Equals("guardar"))
            {
                return RedirectToAction("Clientes");
            }
            return RedirectToAction("NuevoCliente");
        }

        [HttpGet]
        public IActionResult EditarCliente(int idCliente)
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Login");
            }
            Cliente cliente = clienteServicio.ObtenerPorId(idCliente);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente Cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(Cliente);
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.Modificar(Cliente,idUsuario);

            return RedirectToAction("Clientes");
        }

        [HttpGet]
        public IActionResult Borrarcliente(int idCliente)
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.BorrarPorId(idCliente,idUsuario);
            return RedirectToAction("Clientes");
        }

    }
}
