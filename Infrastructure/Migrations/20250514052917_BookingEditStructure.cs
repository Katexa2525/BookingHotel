using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookingEditStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceDate",
                schema: "dbo",
                table: "Bookings",
                newName: "ArrivalDate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                schema: "dbo",
                table: "Bookings",
                newName: "RaceDate");
        }
    }
}
