using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Models.DTO;

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

            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null & admin != "True")
            {
                TempData["Error"] = "Solo los usuarios admin pueden ingresar a esta sección.";
                return RedirectToAction("Index", "Home");
            }

            return View("Usuarios", _usuarioServicio.ListarNoEliminados());
        }

        [HttpPost]
        public IActionResult TodosLosUsuarios()
        {

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();



            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;


            List<UsuarioDatatableDTO> usuarios = _usuarioServicio.mapearListaUsuariosAListaUsuariosDatatableDTO(_usuarioServicio.ListarTodos());

            if (!string.IsNullOrEmpty(searchValue))
            {

                usuarios = usuarios.Where(u => Regex.IsMatch(u.IdUsuario.ToString(), searchValue) || Regex.IsMatch(u.Nombre.ToLower(), searchValue.ToLower()) || Regex.IsMatch(u.Email.ToLower(), searchValue.ToLower())).ToList();
            }

            recordsTotal = usuarios.Count();

            var data = usuarios.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }


        [HttpGet]
        public IActionResult NuevoUsuario()
        {

            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;

            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;

            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";

                return RedirectToAction("Login", "Login");

            }

            if (admin != null && admin != "True")
            {
                TempData["Error"] = "Solo los usuarios admin pueden ingresar a esta sección.";

                return RedirectToAction("Index", "Home");
            }

            return View("NuevoUsuario");


        }

        [HttpPost]
        public IActionResult NuevoUsuario(Usuario usuario, string guardar)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null & admin != "True")
            {
                TempData["Error"] = "Solo los usuarios admin pueden ingresar a esta sección.";
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Por favor complete el usuario con las validaciones correspondientes";
                return View(usuario);
            }
            try
            {

                int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");
                _usuarioServicio.Crear(usuario, idUsuario);


                if (guardar.ToLower().Equals("guardar"))
                {
                    TempData["Success"] = "El usuario:  " + usuario.Nombre + " " + usuario.Apellido + " se ha creado correctamente";
                    return RedirectToAction(nameof(Usuarios));
                }
                TempData["Success"] = "El usuario:  " + usuario.Nombre + " " + usuario.Apellido + " se ha creado correctamente";

                return RedirectToAction(nameof(NuevoUsuario));

            }

            catch (Exception e)
            {

                TempData["Error"] = "Ocurrió un error al crear el usuario, por favor intente de nuevo!";
                TempData["errorException"] = e.ToString();
                return RedirectToAction("ErrorPage", "Home");
            }

        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {

            string idUsuario = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;

            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;

            if (idUsuario == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";

                return RedirectToAction("Login", "Login");
            }

            if (admin != null & admin != "True")
            {

                TempData["Error"] = "Solo los usuarios admines pueden ingresar a esta sección.";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                Usuario usuario = _usuarioServicio.ObtenerPorId(id);

                return View(usuario);

            }
            catch (Exception e)
            {

                TempData["errorException"] = e.ToString();
                return RedirectToAction("ErrorPage", "Home");
            }


        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;
            if (idUsuario2 == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";
                return RedirectToAction("Login", "Login");
            }
            if (admin != null & admin != "True")
            {
                TempData["Error"] = "Solo los usuarios admin pueden ingresar a esta sección.";
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Por favor complete el usuario con las validaciones correspondientes";
                return View(usuario);
            }
            try
            {

                int idUsuario = (int)HttpContext.Session.GetInt32("IdUser");

                _usuarioServicio.Modificar(usuario, idUsuario);

                TempData["Success"] = "El usuario:  " + usuario.Nombre + " " + usuario.Apellido + " se ha modificado correctamente";

                return RedirectToAction(nameof(Usuarios));

            }

            catch (Exception e)
            {

                TempData["Error"] = "Ocurrió un error al editar el usuario, por favor intente de nuevo!";
                TempData["errorException"] = e.ToString();
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        [HttpGet]
        public IActionResult BajaUsuario(int IdUsuario, string guardar)
        {

            string IdUsuarioDeLaBaja = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;

            string admin = HttpContext.Session.GetString("usuarioAdmin") != null ? HttpContext.Session.GetString("usuarioAdmin") : null;

            if (IdUsuarioDeLaBaja == null)
            {
                TempData["Error"] = "Por favor, inicie sesión para poder ingresar a esta sección.";

                return RedirectToAction("Login", "Login");
            }

            if (admin != null & admin != "True")
            {

                TempData["Error"] = "Solo los usuarios admines pueden ingresar a esta sección.";

                return RedirectToAction("Index", "Home");
            }

            try
            {

                Usuario usuario = _usuarioServicio.ObtenerPorId(IdUsuario);

                _usuarioServicio.BorrarPorId(IdUsuario, Convert.ToInt32(IdUsuarioDeLaBaja));


                TempData["Success"] = "El usuario:  " + usuario.Nombre + " " + usuario.Apellido + " se ha borrado correctamente";


                return RedirectToAction(nameof(Usuarios));
            }

            catch (Exception e)
            {

                TempData["Error"] = "Ocurrió un error al eliminar el usuario, por favor intente de nuevo!";
                TempData["errorException"] = e.ToString();
                return RedirectToAction("ErrorPage", "Home");
            }

        }


    }
}

