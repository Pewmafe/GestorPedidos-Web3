using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using System.Globalization;


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
            _usuarioServicio.Crear(usuario);

            return RedirectToAction(nameof(Usuarios));
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            return View("EditarUsuario", _usuarioServicio.ObtenerPorId(id));

        }

        [HttpPost]
        public IActionResult EditarUsuario(int IdUsuario, String Email, String Password, bool EsAdmin, String Nombre, String Apellido, DateTime FechaNacimiento)
        {
            _usuarioServicio.Modificar(IdUsuario, Email, Password, EsAdmin, Nombre, Apellido, FechaNacimiento);
            return RedirectToAction(nameof(Usuarios));
        }

        public IActionResult BajaUsuario(int id)
        {
            _usuarioServicio.BorrarPorId(id);

            return RedirectToAction(nameof(Usuarios));
        }

       
    }
}
