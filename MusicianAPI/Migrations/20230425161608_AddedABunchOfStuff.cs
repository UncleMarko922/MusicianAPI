using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedABunchOfStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandId",
                table: "FavoriteMusicians");

            migrationBuilder.CreateTable(
                name: "FavoriteGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteGenres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteArtists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenereIdGenreId = table.Column<int>(type: "int", nullable: false),
                    MusicianID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArtists", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_FavoriteArtists_FavoriteGenres_GenereIdGenreId",
                        column: x => x.GenereIdGenreId,
                        principalTable: "FavoriteGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteArtists_FavoriteMusicians_MusicianID",
                        column: x => x.MusicianID,
                        principalTable: "FavoriteMusicians",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArtists_GenereIdGenreId",
                table: "FavoriteArtists",
                column: "GenereIdGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArtists_MusicianID",
                table: "FavoriteArtists",
                column: "MusicianID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteArtists");

            migrationBuilder.DropTable(
                name: "FavoriteGenres");

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "FavoriteMusicians",
                type: "int",
                nullable: true);
        }
    }
}
