using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace GestorPedidos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {

            return View("Usuarios");
        }

        public IActionResult NuevoUsuario(Usuario user)
        {

            return View("NuevoUsuario");
        }

        public IActionResult EditarUsuario()
        {

            return View("EditarUsuario");
        }
    }
}
