using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMechRent.Entidades
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int TipoVehiculoId { get; set; }
        public TipoVehiculo? TipoVehiculo { get; set; }
        public int HorasTrabajadas { get; set; }
        public string placa { get; set; }
       // public ICollection<VehiculoObra> VehiculoObras { get; set; }
    }

}
