namespace WebApiMechRent.DTOs
{
    public class VehiculoMantenimientoDto
    {
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string TipoVehiculo { get; set; } // Nueva propiedad para el tipo de vehículo
        public int HorasRestantes { get; set; }
    }
}
