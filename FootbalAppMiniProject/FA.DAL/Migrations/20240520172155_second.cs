using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DropCount",
                table: "Teams",
                newName: "DrawCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrawCount",
                table: "Teams",
                newName: "DropCount");
        }
    }
}
