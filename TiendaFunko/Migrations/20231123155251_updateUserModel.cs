using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class updateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Usuario",
                newName: "Credencial");

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "STW001004", 15 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "PKM001003", 15 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "HPT001003", 15 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "PKM001001", 15 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "HPT001001", 15 });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SKU", "Stock" },
                values: new object[] { "STW001001", 15 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Credencial", "Password" },
                values: new object[] { 1, "BBAF85A574B5B26907872548398B034EDB8DD7D794CE74D4E4461EBFA6224581" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Credencial",
                table: "Usuario",
                newName: "Dni");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Usuario",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dni", "Password", "User" },
                values: new object[] { 37685225, "123456789", "MLascares" });
        }
    }
}
