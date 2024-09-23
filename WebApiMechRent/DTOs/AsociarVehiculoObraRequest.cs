namespace WebApiMechRent.DTOs
{
    public class AsociarVehiculoObraRequest
    {
        public int VehiculoId { get; set; }
        public int ObraId { get; set; }
        public int HorasTrabajadas { get; set; }
    }
}
