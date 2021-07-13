using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using Models.Models;
using System.Text.RegularExpressions;

namespace api.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioServicio _usuarioServicio;
        private _20211CTPContext _context;

        public UsuarioController(_20211CTPContext ctx)
        {
            this._context = ctx;
            this._usuarioServicio = new UsuarioServicio(ctx);
        }

        [HttpPost]
        [Route("[controller]")]
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
                usuariosNoEliminados = usuariosNoEliminados.OrderBy(u => u.IdUsuario).ToList();
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
    }
}
