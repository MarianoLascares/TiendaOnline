using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFunkoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Funko",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Funko",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Funko");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Funko");
        }
    }
}
