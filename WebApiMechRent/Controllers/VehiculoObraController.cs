using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMechRent.Entidades;

namespace WebApiMechRent.Controllers
{
    [ApiController]
    [Route("api/vehiculoobra")]
    public class VehiculoObraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiculoObraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DTOs.AsociarVehiculoObraRequest request)
        {
            var vehiculo = await _context.Vehiculos
                .Include(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(v => v.Id == request.VehiculoId);

            if (vehiculo == null)
            {
                return NotFound($"El vehículo con Id {request.VehiculoId} no existe.");
            }

            var estimado = await _context.EstimadosObras
                .FirstOrDefaultAsync(e => e.ObraId == request.ObraId && e.TipoVehiculoId == vehiculo.TipoVehiculoId);

            if (estimado == null)
            {
                return BadRequest($"El tipo de vehículo {vehiculo.TipoVehiculo?.Nombre} no está estimado para la obra.");
            }

            var vehiculoObra = new VehiculoObra
            {
                VehiculoId = request.VehiculoId,
                ObraId = request.ObraId,
                HorasTrabajadas = request.HorasTrabajadas
            };

            _context.VehiculosObras.Add(vehiculoObra);
            await _context.SaveChangesAsync();

            return Ok(vehiculoObra);
        }
              
    }
}
