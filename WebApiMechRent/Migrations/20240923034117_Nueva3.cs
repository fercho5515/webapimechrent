using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMechRent.Migrations
{
    /// <inheritdoc />
    public partial class Nueva3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "EstimadosObras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EstimadosObras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
