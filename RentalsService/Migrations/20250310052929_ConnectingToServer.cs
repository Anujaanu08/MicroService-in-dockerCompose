using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalsService.Migrations
{
    /// <inheritdoc />
    public partial class ConnectingToServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "AnuRentals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnuRentals",
                table: "AnuRentals",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnuRentals",
                table: "AnuRentals");

            migrationBuilder.RenameTable(
                name: "AnuRentals",
                newName: "Rentals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");
        }
    }
}
