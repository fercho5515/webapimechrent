using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMechRent.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "EstimadosTipoVehiculoObra",
           columns: table => new
           {
               Id = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"), // Nueva propiedad IDENTITY
               ObraId = table.Column<int>(nullable: false),
               TipoVehiculoId = table.Column<int>(nullable: false),
               HorasEstimadas = table.Column<int>(nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_EstimadosTipoVehiculoObra_Temp", x => x.Id);
           });
            migrationBuilder.DropPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras");

            migrationBuilder.DropIndex(
                name: "IX_EstimadosObras_ObraId",
                table: "EstimadosObras");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EstimadosObras",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras",
                columns: new[] { "ObraId", "TipoVehiculoId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EstimadosObras",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EstimadosObras_ObraId",
                table: "EstimadosObras",
                column: "ObraId");
        }
    }
}
