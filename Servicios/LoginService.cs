using Microsoft.AspNetCore.Http;
using Models.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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
            return _dbContext.Usuarios.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault();
        }

        public void LogOut(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
