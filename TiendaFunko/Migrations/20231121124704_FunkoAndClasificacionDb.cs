using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaFunko.Migrations
{
    /// <inheritdoc />
    public partial class FunkoAndClasificacionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImgCaja = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClasificacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funko", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funko_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funko_ClasificacionId",
                table: "Funko",
                column: "ClasificacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funko");

            migrationBuilder.DropTable(
                name: "Clasificacion");
        }
    }
}
