using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "FacturaProducto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Clasificacion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Star Wars" },
                    { 2, "Pokemon" },
                    { 3, "Harry Poter" }
                });

            migrationBuilder.InsertData(
                table: "Funko",
                columns: new[] { "Id", "ClasificacionId", "Description", "DescriptionImg", "DescriptionImgCaja", "Img", "ImgCaja", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Figura coleccionable Funko de un Stromtrooper", "Figura coleccionable Funko de un Stromtrooper", "Figura coleccionable Funko de un Stromtrooper en caja", "~/img/star-wars/trooper-1.webp", "~./img/star-wars/trooper-box.webp", "Stormtrooper Lightsaber", 1799.99m },
                    { 2, 2, "Figura coleccionable Funko de Pidgeotto", "Figura coleccionable Funko de Pidgeotto", "Figura coleccionable Funko de Pidgeotto en caja", "~/img/star-wars/trooper-1.webp", "~/img/pokemon/pidgeotto-box.webp", "Pidgeotto", 1799.99m },
                    { 3, 3, "Figura coleccionable Funko de Luna Lovegood", "Figura coleccionable Funko de Luna Lovegood", "Figura coleccionable Funko de Luna Lovegood en caja", "~/img/harry-potter/luna-1.webp", "~/img/harry-potter/luna-box.webp", "Luna Lovegood Lion Mask", 1799.99m },
                    { 4, 2, "Figura coleccionable Funko de Charmander", "Figura coleccionable Funko de Charmander", "Figura coleccionable Funko de Charmander en caja", "~/img/pokemon/charmander-1.webp", "~/img/pokemon/charmander-box.webp", "Charmander", 1799.99m },
                    { 5, 3, "Figura coleccionable Funko de Harry Potter", "Figura coleccionable Funko de Harry Potter", "Figura coleccionable Funko de Harry Potter en caja", "~/img/harry-potter/harry-1.webp", "~/img/harry-potter/harry-box.webp", "Harry Potter", 1799.99m },
                    { 6, 1, "Figura coleccionable Funco de Baby Yoda", "Figura coleccionable Funco de Baby Yoda", "Figura coleccionable Funco de Baby Yoda en caja", "~/img/star-wars/baby-yoda-1.webp", "~/img/star-wars/baby-yoda-box.webp", "Baby Yoda", 1799.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clasificacion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clasificacion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clasificacion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Total",
                table: "FacturaProducto");
        }
    }
}
