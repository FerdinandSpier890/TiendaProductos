using Microsoft.AspNetCore.Mvc;

namespace TiendaProductos.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PedidosPorProveedor()
        {
            return View();
        }
    }
}
