using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMechRent.Entidades
{
    public class TipoVehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CostoPorHora { get; set; }
        public int HorasMantenimiento { get; set; }
       // public ICollection<Vehiculo> Vehiculos { get; set; }
       // public ICollection<EstimadosTipoVehiculoObra> EstimadosObra { get; set; }
    }

}
