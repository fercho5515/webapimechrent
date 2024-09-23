namespace WebApiMechRent.DTOs
{
    public class ValorHorasTrabajadasDto
    {
        public string Obra { get; set; }
        public int ObraId { get; set; }
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string TipoVehiculo { get; set; }
        public int Horas {get; set;}
        public int ValorHora { get; set; }
        public decimal ValorTotalHoras { get; set; }
    }

}
