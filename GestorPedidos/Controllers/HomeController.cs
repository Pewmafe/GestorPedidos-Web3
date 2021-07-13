using Microsoft.AspNetCore.Mvc;

namespace GestorPedidos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ErrorPage()
        {
           
            return View();
        }

    }
}
