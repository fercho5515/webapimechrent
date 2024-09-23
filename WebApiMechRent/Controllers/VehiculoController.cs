using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMechRent.DTOs;
using WebApiMechRent.Entidades;

namespace WebApiMechRent.Controllers
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VehiculoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
            return await _context.Vehiculos
                .Include(v => v.TipoVehiculo)
                //.Include(v => v.VehiculoObras)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                return BadRequest("El vehículo no puede ser nulo.");
            }

            var tipoVehiculo = await _context.TipoVehiculos.FindAsync(vehiculo.TipoVehiculoId);
            if (tipoVehiculo == null)
            {
                return NotFound($"TipoVehiculo con Id {vehiculo.TipoVehiculoId} no existe.");
            }

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return Ok(vehiculo);
        }

        [HttpGet("vehiculos/bajo-mantenimiento")]
        public async Task<ActionResult<IEnumerable<VehiculoMantenimientoDto>>> ObtenerVehiculosBajoMantenimiento()
        {
            var vehiculos = await _context.Vehiculos
                .Include(v => v.TipoVehiculo)
                .ToListAsync();

            var vehiculosBajoMantenimiento = new List<VehiculoMantenimientoDto>();

            foreach (var vehiculo in vehiculos)
            {
                var horasTrabajadas = await _context.VehiculosObras
                    .Where(vo => vo.VehiculoId == vehiculo.Id)
                    .SumAsync(vo => vo.HorasTrabajadas);

                var horasRestantesMantenimiento = vehiculo.TipoVehiculo.HorasMantenimiento - horasTrabajadas;

                if (horasRestantesMantenimiento < 120)
                {
                    vehiculosBajoMantenimiento.Add(new VehiculoMantenimientoDto
                    {
                        VehiculoId = vehiculo.Id,
                        Placa = vehiculo.placa,
                        TipoVehiculo = vehiculo.TipoVehiculo.Nombre, 
                        HorasRestantes = horasRestantesMantenimiento
                    });
                }
            }
            return Ok(vehiculosBajoMantenimiento);
        }


    }
}
