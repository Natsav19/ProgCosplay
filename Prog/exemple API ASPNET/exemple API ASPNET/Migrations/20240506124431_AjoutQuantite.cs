using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemple_API_ASPNET.Migrations
{
    public partial class AjoutQuantite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "Cosplay",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Cosplay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Cosplay");

            migrationBuilder.AlterColumn<string>(
                name: "Prix",
                table: "Cosplay",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
