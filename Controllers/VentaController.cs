using Microsoft.AspNetCore.Mvc;


namespace Integrando_Apis_con_Ado.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venta>> GetAllVentas()
        {
            var ventas = _ventaService.GetAllVentas();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public ActionResult<Venta> GetVentaById(int id)
        {
            var venta = _ventaService.GetVentaById(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public ActionResult<Venta> CreateVenta(Venta venta)
        {
            _ventaService.CreateVenta(venta);
            return CreatedAtAction(nameof(GetVentaById), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }
            _ventaService.UpdateVenta(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVenta(int id)
        {
            var existingVenta = _ventaService.GetVentaById(id);
            if (existingVenta == null)
            {
                return NotFound();
            }
            _ventaService.DeleteVenta(id);
            return NoContent();
        }
    }
}
