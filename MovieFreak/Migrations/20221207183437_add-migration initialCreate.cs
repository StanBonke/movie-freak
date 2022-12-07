using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieFreak.Migrations
{
    public partial class addmigrationinitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MovieFreak");

            migrationBuilder.CreateTable(
                name: "Genre",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmGenre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persoon",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Geboorteplaats = table.Column<string>(nullable: true),
                    Geboorteland = table.Column<string>(nullable: true),
                    Biografie = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taal",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GesprokenTaal = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: false),
                    Duurtijd = table.Column<string>(nullable: false),
                    Trailerlink = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_Genre_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "MovieFreak",
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filmtaal",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    TaalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmtaal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmtaal_Film_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "MovieFreak",
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmtaal_Taal_TaalId",
                        column: x => x.TaalId,
                        principalSchema: "MovieFreak",
                        principalTable: "Taal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personage",
                schema: "MovieFreak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoornaamPersonage = table.Column<string>(nullable: true),
                    AchternaamPersonage = table.Column<string>(nullable: true),
                    FilmId = table.Column<int>(nullable: false),
                    PersoonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personage_Film_FilmId",
                        column: x => x.FilmId,
                        principalSchema: "MovieFreak",
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personage_Persoon_PersoonId",
                        column: x => x.PersoonId,
                        principalSchema: "MovieFreak",
                        principalTable: "Persoon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_GenreId",
                schema: "MovieFreak",
                table: "Film",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmtaal_FilmId",
                schema: "MovieFreak",
                table: "Filmtaal",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmtaal_TaalId",
                schema: "MovieFreak",
                table: "Filmtaal",
                column: "TaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personage_FilmId",
                schema: "MovieFreak",
                table: "Personage",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Personage_PersoonId",
                schema: "MovieFreak",
                table: "Personage",
                column: "PersoonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmtaal",
                schema: "MovieFreak");

            migrationBuilder.DropTable(
                name: "Personage",
                schema: "MovieFreak");

            migrationBuilder.DropTable(
                name: "Taal",
                schema: "MovieFreak");

            migrationBuilder.DropTable(
                name: "Film",
                schema: "MovieFreak");

            migrationBuilder.DropTable(
                name: "Persoon",
                schema: "MovieFreak");

            migrationBuilder.DropTable(
                name: "Genre",
                schema: "MovieFreak");
        }
    }
}