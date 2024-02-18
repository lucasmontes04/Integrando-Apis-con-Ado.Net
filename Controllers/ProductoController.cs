using Microsoft.AspNetCore.Mvc;

namespace Integrando_Apis_con_Ado.Net.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
