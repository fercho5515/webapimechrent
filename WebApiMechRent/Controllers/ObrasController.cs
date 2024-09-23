using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMechRent.DTOs;
using WebApiMechRent.Entidades;

namespace WebApiMechRent.Controllers
{
    [ApiController]
    [Route("api/obras")]
    public class ObrasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ObrasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("obras/estimados")]
        public async Task<ActionResult<Obra>> GetObrasConEstimados()
        {
            var obras = await _context.Obras
                .Include(o => o.EstimadosTipoVehiculo)
                .ThenInclude(e => e.TipoVehiculo)
                .ToListAsync();

            return Ok(obras);
        }

        [HttpGet("obras/{obraId}/estimados")]
        public async Task<ActionResult<Obra>> GetObraConEstimadosPorId(int obraId)
        {
            var obra = await _context.Obras
                .Include(o => o.EstimadosTipoVehiculo)  
                .ThenInclude(e => e.TipoVehiculo)       
                .FirstOrDefaultAsync(o => o.Id == obraId);  

            if (obra == null)
            {
                return NotFound($"La obra con el Id {obraId} no fue encontrada.");
            }

            return Ok(obra);
        }

        [HttpGet("obras/detalles/{obraId}")]
        public async Task<ActionResult<Obra>> GetObraConDetalles(int obraId)
        {
            var obra = await _context.Obras
                .Include(o => o.VehiculoObras)
                .ThenInclude(vo => vo.Vehiculo)
                .ThenInclude(v => v.TipoVehiculo)
                .FirstOrDefaultAsync(o => o.Id == obraId);

            if (obra == null)
            {
                return NotFound("Obra no encontrada.");
            }

            return Ok(obra);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Obra obra)
        {
            if (obra == null)
            {
                return BadRequest("La obra no puede ser nula.");
            }

            _context.Obras.Add(obra);
            await _context.SaveChangesAsync();

            return Ok(obra);
        }

        [HttpGet("obras/{obraId}/vehiculos/{vehiculoId}/valor-horas")]
        public async Task<ActionResult<ValorHorasTrabajadasDto>> ObtenerValorHorasTrabajadas(int obraId, int vehiculoId)
        {
            var vehiculoObras = await _context.VehiculosObras
                .Include(vo => vo.Vehiculo)
                .ThenInclude(v => v.TipoVehiculo)
                .Where(vo => vo.ObraId == obraId && vo.VehiculoId == vehiculoId)
                .ToListAsync();

            var obra = await _context.Obras
                .FirstOrDefaultAsync(ob => ob.Id == obraId);

            if (!vehiculoObras.Any())
            {
                return NotFound("El vehículo no tiene registros en esta obra.");
            }

            var primerRegistro = vehiculoObras.First();
            var costoPorHora = primerRegistro.Vehiculo.TipoVehiculo.CostoPorHora;
            var totalHorasTrabajadas = vehiculoObras.Sum(vo => vo.HorasTrabajadas);
            var valorTotalHoras = totalHorasTrabajadas * costoPorHora;
            
            var resultado = new ValorHorasTrabajadasDto
            {
                ObraId = obra.Id,
                Obra = obra.Nombre,
                VehiculoId = primerRegistro.Vehiculo.Id,
                Placa = primerRegistro.Vehiculo.placa,
                TipoVehiculo = primerRegistro.Vehiculo.TipoVehiculo.Nombre,
                Horas = totalHorasTrabajadas,
                ValorHora = costoPorHora,
                ValorTotalHoras = valorTotalHoras
            };

            return Ok(resultado);
        }

    }
}
