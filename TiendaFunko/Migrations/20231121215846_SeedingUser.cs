using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/star-wars/trooper-1.webp", "../../img/star-wars/trooper-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/star-wars/trooper-1.webp", "../../img/pokemon/pidgeotto-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/harry-potter/luna-1.webp", "../../img/harry-potter/luna-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/pokemon/charmander-1.webp", "../../img/pokemon/charmander-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/harry-potter/harry-1.webp", "../../img/harry-potter/harry-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "../../img/star-wars/baby-yoda-1.webp", "../../img/star-wars/baby-yoda-box.webp" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Direccion", "Dni", "Email", "Nombre", "Password", "User" },
                values: new object[] { 1, "Lascares", "San Juan 1349", 37685225, "mariano.lascares@gmail.com", "Mariano", "123456789", "MLascares" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/star-wars/trooper-1.webp", "~./img/star-wars/trooper-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/star-wars/trooper-1.webp", "~/img/pokemon/pidgeotto-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/harry-potter/luna-1.webp", "~/img/harry-potter/luna-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/pokemon/charmander-1.webp", "~/img/pokemon/charmander-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/harry-potter/harry-1.webp", "~/img/harry-potter/harry-box.webp" });

            migrationBuilder.UpdateData(
                table: "Funko",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Img", "ImgCaja" },
                values: new object[] { "~/img/star-wars/baby-yoda-1.webp", "~/img/star-wars/baby-yoda-box.webp" });
        }
    }
}
