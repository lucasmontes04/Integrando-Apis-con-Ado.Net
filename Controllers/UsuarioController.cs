using Microsoft.AspNetCore.Mvc;

namespace Integrando_Apis_con_Ado.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }
        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return this.usuarioService.ObtenerTodosLosUsuarios();
        }
    }
}