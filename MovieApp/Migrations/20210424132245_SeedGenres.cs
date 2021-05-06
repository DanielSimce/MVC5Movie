using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class SeedGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name) VALUES ('Comedy'),('Horror'),('Action')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
