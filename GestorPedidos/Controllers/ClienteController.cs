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
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            List<Cliente> clientes = new List<Cliente>();
            if (TempData["Eliminados"] != null)
            {
                clientes = clienteServicio.ListarNoEliminados();
                ViewData["ExcluirEliminados"] = true;
            }
            else
            {
                clientes = clienteServicio.ListarTodos();
                ViewData["ExcluirEliminados"] = false;
            }

            return View(clientes);
        }

        public IActionResult NuevoCliente()
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult NuevoCliente(Cliente cliente, string guardar)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");

            if (cliente.Email != null)
            {
                if (clienteServicio.emailExistente(cliente.Email))
                {
                    TempData["Error"] = "Ya existe un cliente con ese email.";
                    return View(cliente);
                }
            }

            clienteServicio.Crear(cliente, idUsuario);

            if (guardar.ToLower().Equals("guardar"))
            {
                TempData["Success"] = "Cliente  '" + cliente.Nombre + "' agregado correctamente";
                return RedirectToAction("Clientes");
            }
            TempData["Success"] = "Cliente  '" + cliente.Nombre + "' agregado correctamente";
            return RedirectToAction("NuevoCliente");
        }

        [HttpGet]
        public IActionResult EditarCliente(int idCliente)
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            Cliente cliente = clienteServicio.ObtenerPorId(idCliente);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente Cliente)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(Cliente);
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.Modificar(Cliente, idUsuario);

            TempData["Success"] = "Cliente  '" + Cliente.Nombre + "' modificado correctamente";
            return RedirectToAction("Clientes");
        }

        [HttpGet]
        public IActionResult Borrarcliente(int idCliente)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.BorrarPorId(idCliente, idUsuario);
            Cliente cliente = this.clienteServicio.ObtenerPorId(idCliente);
            TempData["Success"] = "Cliente  '" + cliente.Nombre + "' borrado correctamente";
            return RedirectToAction("Clientes");
        }

        [HttpGet]
        public IActionResult ClientesNoEliminados()
        {
            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, Inicie Sesion para poder ingresar a esta seccion.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null && admin != "True")
            {
                TempData["warning"] = "Usted no se encuentra habilitado para ingresar en esta seccion.";
                return RedirectToAction("Index", "Home");
            }
            TempData["Eliminados"] = true;
            return RedirectToAction("Clientes");
        }

    }
}
