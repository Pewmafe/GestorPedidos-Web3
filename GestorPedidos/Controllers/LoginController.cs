using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using Service;
using Service.Interface;

namespace GestorPedidos.Controllers
{
    public class LoginController : Controller
    {

        private ILoginServicio loginServicio;
        private _20211CTPContext dbContext;

        public LoginController(_20211CTPContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.loginServicio = new LoginService(dbContext);
        }


        [HttpGet]
        public IActionResult Login()
        {
            string idUsuario2 = HttpContext.Session.GetString("IdUsuario") != null ? HttpContext.Session.GetString("IdUsuario") : null;
            if (idUsuario2 != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            Usuario usuarioValidado = loginServicio.LogIn(usuario);
            if (usuarioValidado == null)
            {
                TempData["Error"] = "Email o contraseña incorrecto.";
                return RedirectToAction("Login");
            }
            this.GuardarInformacionSesion(usuarioValidado);

            return RedirectToAction("Pedido", "Pedido");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            loginServicio.LogOut(HttpContext);
            return RedirectToAction("Login");
        }

        private void GuardarInformacionSesion(Usuario usuario)
        {
            HttpContext.Session.SetString("IdUsuario", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre.ToString());
            HttpContext.Session.SetString("ApellidoUsuario", usuario.Apellido.ToString());
            HttpContext.Session.SetString("usuarioAdmin", usuario.EsAdmin.ToString());
            HttpContext.Session.SetInt32("IdUser", usuario.IdUsuario);
        }
    }
}
