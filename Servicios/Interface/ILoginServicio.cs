using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface ILoginServicio
    {
        Usuario LogIn(Usuario usuario);
        void LogOut(HttpContext httpContext);
    }
}
