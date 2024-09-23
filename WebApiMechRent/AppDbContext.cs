using Microsoft.EntityFrameworkCore;
using WebApiMechRent.Entidades;

namespace WebApiMechRent
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<EstimadosTipoVehiculoObra> EstimadosObras { get; set; }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstimadosTipoVehiculoObra>()
                .HasKey(e => new { e.ObraId, e.TipoVehiculoId }); 
        }*/
        public DbSet<VehiculoObra> VehiculosObras { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones de la llave compuesta para VehiculoObra
            modelBuilder.Entity<VehiculoObra>()
                .HasKey(vo => new { vo.ObraId, vo.VehiculoId });

            base.OnModelCreating(modelBuilder);
        }*/

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
    
}
