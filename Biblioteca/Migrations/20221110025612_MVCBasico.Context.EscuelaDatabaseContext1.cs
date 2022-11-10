using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class MVCBasicoContextEscuelaDatabaseContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Libros_IdLibro",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Personas_LectorIdPersona",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_IdLibro",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_LectorIdPersona",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "LectorIdPersona",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "Prestamos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "libroIdLibro",
                table: "Prestamos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "personaIdPersona",
                table: "Prestamos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_libroIdLibro",
                table: "Prestamos",
                column: "libroIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_personaIdPersona",
                table: "Prestamos",
                column: "personaIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Libros_libroIdLibro",
                table: "Prestamos",
                column: "libroIdLibro",
                principalTable: "Libros",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Personas_personaIdPersona",
                table: "Prestamos",
                column: "personaIdPersona",
                principalTable: "Personas",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Libros_libroIdLibro",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Personas_personaIdPersona",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_libroIdLibro",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_personaIdPersona",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "libroIdLibro",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "personaIdPersona",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LectorIdPersona",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdLibro",
                table: "Prestamos",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LectorIdPersona",
                table: "Prestamos",
                column: "LectorIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Libros_IdLibro",
                table: "Prestamos",
                column: "IdLibro",
                principalTable: "Libros",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Personas_LectorIdPersona",
                table: "Prestamos",
                column: "LectorIdPersona",
                principalTable: "Personas",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
