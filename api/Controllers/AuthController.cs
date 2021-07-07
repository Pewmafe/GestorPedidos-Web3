using api.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Models;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {


        private ILoginServicio loginServicio;
        private _20211CTPContext dbContext;
        private readonly IConfiguration conf;

        public AuthController(_20211CTPContext _dbContext, IConfiguration config)
        {
            this.dbContext = _dbContext;
            this.loginServicio = new LoginService(dbContext);
            this.conf = config;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<object> Login(Usuario usuario)
        {
            Usuario usuarioValidado = loginServicio.LogIn(usuario);
            if (usuarioValidado == null)
            {
                return Unauthorized();
            }
            string secret = this.conf.GetValue<string>("Secret");
            JWTHelper jwtHelper = new JWTHelper(secret);
            string token = jwtHelper.CreateToken(usuario.Email);

            return Ok(new
            {
                Email = usuarioValidado.Email,
                IdUsuario = usuarioValidado.IdUsuario,
                Nombre = usuarioValidado.Nombre,
                Apellido = usuarioValidado.Apellido,
                FechaNacimiento= usuarioValidado.FechaNacimiento,
                token
            });
        }

         [HttpPost]
         [Route("logout")]
         public object Logout()
         {
                
         return new
         {
            mensaje = "Ha cerrado sesión exitosamente"
         };
            
        }   
    }
}
