using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Text.RegularExpressions;

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
            List<Cliente> clientes = clienteServicio.ListarTodos();
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
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            clienteServicio.BorrarPorId(idCliente, idUsuario);
            Cliente cliente = this.clienteServicio.ObtenerPorId(idCliente);
            TempData["Success"] = "Cliente  '" + cliente.Nombre + "' borrado correctamente";
            return RedirectToAction("Clientes");
        }

        [HttpPost]
        public IActionResult ClientesNoEliminados()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();


            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // Getting all Customer data    
            List<Cliente> clientesNoEliminados = clienteServicio.ListarNoEliminados();

            //Sorting    
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                clientesNoEliminados = clientesNoEliminados.OrderBy(u => u.IdCliente).ToList();
            }
            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {

                clientesNoEliminados = clientesNoEliminados.Where(u => Regex.IsMatch(u.IdCliente.ToString(), searchValue) || Regex.IsMatch(u.Nombre.ToLower(), searchValue.ToLower()) || Regex.IsMatch(u.Email.ToLower(), searchValue.ToLower())).ToList();
            }

            //total number of rows count     
            recordsTotal = clientesNoEliminados.Count();
            //Paging     
            var data = clientesNoEliminados.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

    }
}
