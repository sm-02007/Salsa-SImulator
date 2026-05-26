using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalsaSimulator.Migrations
{
    /// <inheritdoc />
    public partial class AddExtrasJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtrasJson",
                table: "Builds",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExtrasJson",
                value: "{\"Mango\":40,\"Pina\":20,\"CebollaMorada\":20,\"Ajo\":3,\"SalPorcentaje\":2,\"DiasFerrmentacion\":5,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExtrasJson",
                value: "{\"Tomate\":30,\"Ajo\":4,\"Limon\":20,\"Especias\":2,\"SalPorcentaje\":2,\"DiasFerrmentacion\":4,\"TemperaturaC\":22}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExtrasJson",
                value: "{\"Zanahoria\":40,\"Tomate\":20,\"Ajo\":4,\"SalPorcentaje\":2.5,\"DiasFerrmentacion\":6,\"TemperaturaC\":24}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExtrasJson",
                value: "{\"Mango\":70,\"CebollaMorada\":30,\"Limon\":20,\"SalPorcentaje\":2,\"DiasFerrmentacion\":3,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExtrasJson",
                value: "{\"Ajo\":5,\"Miel\":20,\"SalPorcentaje\":2,\"DiasFerrmentacion\":7,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExtrasJson",
                value: "{\"VinagreBlanco\":80,\"SalPorcentaje\":3.5,\"DiasFerrmentacion\":7,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExtrasJson",
                value: "{\"Limon\":40,\"CebollaBlanca\":20,\"Ajo\":3,\"SalPorcentaje\":2,\"DiasFerrmentacion\":3,\"TemperaturaC\":22}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExtrasJson",
                value: "{\"Ajo\":15,\"VinagreManzana\":30,\"CebollaBlanca\":10,\"SalPorcentaje\":2.5,\"DiasFerrmentacion\":8,\"TemperaturaC\":24}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExtrasJson",
                value: "{\"Tomate\":40,\"Ajo\":8,\"CebollaBlanca\":10,\"Morron\":20,\"Especias\":3,\"SalPorcentaje\":2.5,\"DiasFerrmentacion\":10,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExtrasJson",
                value: "{\"SalPorcentaje\":2,\"DiasFerrmentacion\":5,\"TemperaturaC\":25}");

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExtrasJson",
                value: "{\"SalPorcentaje\":2,\"DiasFerrmentacion\":3,\"TemperaturaC\":28}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtrasJson",
                table: "Builds");
        }
    }
}
