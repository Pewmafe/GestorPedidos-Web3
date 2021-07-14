using Microsoft.AspNetCore.Http;
using Models.Models;
using Service.Interface;
using System;
using System.Linq;

namespace Service
{
    public class LoginService : ILoginServicio
    {
        private _20211CTPContext _dbContext;

        public LoginService(_20211CTPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario LogIn(Usuario usuario)
        {
            Usuario usuarioLogeado = _dbContext.Usuarios.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault();
            if (usuarioLogeado != null)
            {
                usuarioLogeado.FechaUltLogin = DateTime.Now;
                _dbContext.SaveChanges();
                return usuarioLogeado;
            }
            return null;
        }

        public void LogOut(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
