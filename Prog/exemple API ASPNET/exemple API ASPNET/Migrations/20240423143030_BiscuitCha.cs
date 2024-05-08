using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemple_API_ASPNET.Migrations
{
    public partial class BiscuitCha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProprietaireId",
                table: "Cosplay",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProprietaireId",
                table: "Cosplay");
        }
    }
}
