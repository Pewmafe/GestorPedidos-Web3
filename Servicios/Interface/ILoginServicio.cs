using Models.Models;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface ILoginServicio
    {
        Usuario LogIn(Usuario usuario);
        void LogOut(HttpContext httpContext);
    }
}
