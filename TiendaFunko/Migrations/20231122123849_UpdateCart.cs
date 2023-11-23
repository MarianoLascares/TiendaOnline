using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FacturaProducto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Facturacion",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Facturacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "../../img/pokemon/pidgeotto-1.webp");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaProducto_FacturacionId",
                table: "FacturaProducto",
                column: "FacturacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto");

            migrationBuilder.DropIndex(
                name: "IX_FacturaProducto_FacturacionId",
                table: "FacturaProducto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FacturaProducto");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Facturacion");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Facturacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturaProducto",
                table: "FacturaProducto",
                columns: new[] { "FacturacionId", "FunkoId" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                column: "Img",
                value: "../../img/star-wars/trooper-1.webp");
        }
    }
}
