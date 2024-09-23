using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace WebApiMechRent.Entidades
{
    public class EstimadosTipoVehiculoObra
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }

        public int TipoVehiculoId { get; set; }
        public TipoVehiculo? TipoVehiculo { get; set; }

        public int HorasEstimadas { get; set; }
    }
}
