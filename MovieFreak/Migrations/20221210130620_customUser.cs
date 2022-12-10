using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieFreak.Migrations
{
    public partial class customUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achternaam",
                schema: "MovieFreak",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                schema: "MovieFreak",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achternaam",
                schema: "MovieFreak",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                schema: "MovieFreak",
                table: "AspNetUsers");
        }
    }
}
