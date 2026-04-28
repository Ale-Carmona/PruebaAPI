using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaAPI.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Tabla1",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Descripción de Juan");

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: "Descripción de María");

            migrationBuilder.UpdateData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: "Descripción de Carlos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Tabla1");
        }
    }
}
