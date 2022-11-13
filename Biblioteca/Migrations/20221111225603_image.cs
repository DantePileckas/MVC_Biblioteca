using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Libros",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Libros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
