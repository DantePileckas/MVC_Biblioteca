using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class lectorcambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editorial_oEditorialIdEditorial",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "Editorial");

            migrationBuilder.DropIndex(
                name: "IX_Libros_oEditorialIdEditorial",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "oEditorialIdEditorial",
                table: "Libros");

            migrationBuilder.AddColumn<bool>(
                name: "Disponibilidad",
                table: "Libros",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "Libros");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Libros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "oEditorialIdEditorial",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_oEditorialIdEditorial",
                table: "Libros",
                column: "oEditorialIdEditorial");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editorial_oEditorialIdEditorial",
                table: "Libros",
                column: "oEditorialIdEditorial",
                principalTable: "Editorial",
                principalColumn: "IdEditorial",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
