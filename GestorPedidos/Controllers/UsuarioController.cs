using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using System.Globalization;
using System.Text.RegularExpressions;
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
        [HttpPost]
        public IActionResult UsuariosNoEliminados()
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
            List<Usuario> usuariosNoEliminados = _usuarioServicio.ListarNoEliminados();

            //Sorting    
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                usuariosNoEliminados = usuariosNoEliminados.OrderBy(u=> u.IdUsuario).ToList();
            }
            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                
                     usuariosNoEliminados = usuariosNoEliminados.Where(u => Regex.IsMatch(u.IdUsuario.ToString(), searchValue) || Regex.IsMatch(u.Nombre.ToLower(), searchValue.ToLower()) || Regex.IsMatch(u.Email.ToLower(), searchValue.ToLower())).ToList();
            }

            //total number of rows count     
            recordsTotal = usuariosNoEliminados.Count();
            //Paging     
            var data = usuariosNoEliminados.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
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
