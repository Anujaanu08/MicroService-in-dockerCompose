using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksService.Migrations
{
    /// <inheritdoc />
    public partial class tablenamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AVBooks",
                table: "AVBooks");

            migrationBuilder.RenameTable(
                name: "AVBooks",
                newName: "AnuBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnuBooks",
                table: "AnuBooks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnuBooks",
                table: "AnuBooks");

            migrationBuilder.RenameTable(
                name: "AnuBooks",
                newName: "AVBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AVBooks",
                table: "AVBooks",
                column: "Id");
        }
    }
}
