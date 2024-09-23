using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMechRent.Entidades;


namespace WebApiMechRent.Controllers
{
    [ApiController]
    [Route("api/estimados-obra")]
    public class EstimadosTipoVehiculoObraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstimadosTipoVehiculoObraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EstimadosTipoVehiculoObra estimado)
        {
            var obra = await _context.Obras.FindAsync(estimado.ObraId);
            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(estimado.TipoVehiculoId);

            if (obra == null)
            {
                return NotFound($"La obra con Id {estimado.ObraId} no existe.");
            }

            if (tipoVehiculo == null)
            {
                return NotFound($"El tipo de vehículo con Id {estimado.TipoVehiculoId} no existe.");
            }

            _context.EstimadosObras.Add(estimado);
            await _context.SaveChangesAsync();

            return Ok(estimado);
        }
    }

}
