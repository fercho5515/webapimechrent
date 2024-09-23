using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMechRent.Entidades
{
    public class Obra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public ICollection<EstimadosTipoVehiculoObra>? EstimadosTipoVehiculo { get; set; }
        public ICollection<VehiculoObra>? VehiculoObras { get; set; }
    }
}
