using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieName = table.Column<string>(type: "TEXT", nullable: false),
                    MovieReview = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieDate = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieAgeRange = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
