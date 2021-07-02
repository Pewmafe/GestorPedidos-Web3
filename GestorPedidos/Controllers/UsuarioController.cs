using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace GestorPedidos.Controllers
{
    public class UsuarioController : Controller
    {

        private _20211CTPContext _context;
        private Service.UsuarioServicio _usuarioServicio;

        public UsuarioController(_20211CTPContext context)
        {
            this._context = context;
            this._usuarioServicio = new Service.UsuarioServicio(_context);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Usuarios()
        {
            return View("Usuarios", _usuarioServicio.ListarTodos());
        }
        [HttpGet]
        public IActionResult UsuariosNoEliminados()
        {

            List<Usuario> usuariosNoEliminados = _usuarioServicio.ListarNoEliminados();

            return Json(usuariosNoEliminados); 

        }

        [HttpGet]
        public IActionResult NuevoUsuario()
        {

            return View("NuevoUsuario");
        }

        [HttpPost]
        public IActionResult NuevoUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            _usuarioServicio.Crear(usuario, idUsuario);

            return RedirectToAction(nameof(Usuarios));
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            return View("EditarUsuario", _usuarioServicio.ObtenerPorId(id));

        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            _usuarioServicio.Modificar(usuario,idUsuario);
            return RedirectToAction(nameof(Usuarios));
        }

        public IActionResult BajaUsuario(int id)
        {
            int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
            _usuarioServicio.BorrarPorId(id,idUsuario);

            return RedirectToAction(nameof(Usuarios));
        }

       
    }
}
