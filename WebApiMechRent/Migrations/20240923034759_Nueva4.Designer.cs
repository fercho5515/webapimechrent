﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiMechRent;

#nullable disable

namespace WebApiMechRent.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923034759_Nueva4")]
    partial class Nueva4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiMechRent.Entidades.EstimadosTipoVehiculoObra", b =>
                {
                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<int>("HorasEstimadas")
                        .HasColumnType("int");

                    b.HasKey("ObraId", "TipoVehiculoId");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("EstimadosObras");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.Obra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CostoPorHora")
                        .HasColumnType("int");

                    b.Property<int>("HorasMantenimiento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculos");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HorasTrabajadas")
                        .HasColumnType("int");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<string>("placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.VehiculoObra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HorasTrabajadas")
                        .HasColumnType("int");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObraId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("VehiculosObras");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.EstimadosTipoVehiculoObra", b =>
                {
                    b.HasOne("WebApiMechRent.Entidades.Obra", "Obra")
                        .WithMany("EstimadosTipoVehiculo")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiMechRent.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.Vehiculo", b =>
                {
                    b.HasOne("WebApiMechRent.Entidades.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.VehiculoObra", b =>
                {
                    b.HasOne("WebApiMechRent.Entidades.Obra", "Obra")
                        .WithMany("VehiculoObras")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiMechRent.Entidades.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("WebApiMechRent.Entidades.Obra", b =>
                {
                    b.Navigation("EstimadosTipoVehiculo");

                    b.Navigation("VehiculoObras");
                });
#pragma warning restore 612, 618
        }
    }
}
