using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMechRent.Migrations
{
    /// <inheritdoc />
    public partial class Nueva5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EstimadosObras",
                type: "int",
                nullable: false,
                defaultValue: 0)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras");

            migrationBuilder.DropIndex(
                name: "IX_EstimadosObras_ObraId",
                table: "EstimadosObras");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EstimadosObras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstimadosObras",
                table: "EstimadosObras",
                columns: new[] { "ObraId", "TipoVehiculoId" });
        }
    }
}
