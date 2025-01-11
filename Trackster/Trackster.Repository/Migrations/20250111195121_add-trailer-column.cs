using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackster.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addtrailercolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "trailerUrl",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trailerUrl",
                table: "Media");
        }
    }
}
