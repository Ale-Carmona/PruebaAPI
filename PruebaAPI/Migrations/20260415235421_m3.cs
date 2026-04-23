using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaAPI.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tabla1",
                columns: new[] { "Id", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pérez", "Juan" },
                    { 2, "Gómez", "María" },
                    { 3, "López", "Carlos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tabla1",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
