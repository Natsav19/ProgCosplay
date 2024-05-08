using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemple_API_ASPNET.Migrations
{
    public partial class AjoutValeurWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Cosplay",
                newName: "Titre");

            migrationBuilder.AddColumn<string>(
                name: "Contenu",
                table: "Cosplay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cosplay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prix",
                table: "Cosplay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "nbInventaire",
                table: "Cosplay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contenu",
                table: "Cosplay");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cosplay");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Cosplay");

            migrationBuilder.DropColumn(
                name: "nbInventaire",
                table: "Cosplay");

            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Cosplay",
                newName: "Nom");
        }
    }
}
