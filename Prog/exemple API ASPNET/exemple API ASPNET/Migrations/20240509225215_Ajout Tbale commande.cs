using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemple_API_ASPNET.Migrations
{
    public partial class AjoutTbalecommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommandeCosplayID",
                table: "Cosplay",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommandeCosplay",
                columns: table => new
                {
                    CommandeCosplayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeCosplay", x => x.CommandeCosplayID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosplay_CommandeCosplayID",
                table: "Cosplay",
                column: "CommandeCosplayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosplay_CommandeCosplay_CommandeCosplayID",
                table: "Cosplay",
                column: "CommandeCosplayID",
                principalTable: "CommandeCosplay",
                principalColumn: "CommandeCosplayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosplay_CommandeCosplay_CommandeCosplayID",
                table: "Cosplay");

            migrationBuilder.DropTable(
                name: "CommandeCosplay");

            migrationBuilder.DropIndex(
                name: "IX_Cosplay_CommandeCosplayID",
                table: "Cosplay");

            migrationBuilder.DropColumn(
                name: "CommandeCosplayID",
                table: "Cosplay");
        }
    }
}
