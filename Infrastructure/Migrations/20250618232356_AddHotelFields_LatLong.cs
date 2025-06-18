using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelFields_LatLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                schema: "dbo",
                table: "Hotels",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                schema: "dbo",
                table: "Hotels",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("2cedea9f-912d-48c7-9125-3c11769f71a7"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("6c294357-66e3-49b1-ab63-42173553e89c"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("95175bfc-af50-4588-9373-68ee30e88f75"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("c48cbbe7-6a94-4480-9c60-48b54af81545"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e0c80aaf-2224-40d5-8d54-66bf4fbbfcd8"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "dbo",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "dbo",
                table: "Hotels");
        }
    }
}
