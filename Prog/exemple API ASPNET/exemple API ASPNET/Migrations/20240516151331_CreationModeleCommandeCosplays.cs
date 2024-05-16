using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exemple_API_ASPNET.Migrations
{
    public partial class CreationModeleCommandeCosplays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CommandeCosplays",
                columns: table => new
                {
                    CommandeCosplaysID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CosplayID = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeCosplays", x => x.CommandeCosplaysID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeCosplays");

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
    }
}
