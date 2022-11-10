using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class Biblioteca_Context_BiblioDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Clave = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: false),
                    oEditorialIdEditorial = table.Column<int>(nullable: true),
                    Ejemplares = table.Column<int>(nullable: false),
                    rutaImagen = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Editorial_oEditorialIdEditorial",
                        column: x => x.oEditorialIdEditorial,
                        principalTable: "Editorial",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaToma = table.Column<DateTime>(nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: false),
                    devolucion = table.Column<bool>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    IdPersona = table.Column<int>(nullable: true),
                    LectorIdPersona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Personas_LectorIdPersona",
                        column: x => x.LectorIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_oEditorialIdEditorial",
                table: "Libros",
                column: "oEditorialIdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdLibro",
                table: "Prestamos",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LectorIdPersona",
                table: "Prestamos",
                column: "LectorIdPersona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
