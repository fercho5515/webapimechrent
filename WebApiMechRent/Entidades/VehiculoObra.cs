using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMechRent.Entidades

{
    public class VehiculoObra
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }

        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int HorasTrabajadas { get; set; }

       
    }
}
