using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicianAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Band",
                table: "FavoriteMusicians");

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "FavoriteMusicians",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandId",
                table: "FavoriteMusicians");

            migrationBuilder.AddColumn<string>(
                name: "Band",
                table: "FavoriteMusicians",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
