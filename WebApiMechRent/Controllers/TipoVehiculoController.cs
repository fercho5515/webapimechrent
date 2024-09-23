using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMechRent.Entidades;


namespace WebApiMechRent.Controllers
{
    [ApiController]
    [Route("api/tipovehiculos")]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoVehiculoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoVehiculo>>> Get()
        {
            return await _context.TipoVehiculos
               
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoVehiculo tipoVehiculo)
        {
            if (tipoVehiculo == null)
            {
                return BadRequest("El tipo de vehículo no puede ser nulo.");
            }

            _context.TipoVehiculos.Add(tipoVehiculo);
            await _context.SaveChangesAsync();

            return Ok(tipoVehiculo);
        }
    }
}
