using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class ActualizacionLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "rutaImagen",
                table: "Libros");

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Personas",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Libros",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rutaImagen",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
