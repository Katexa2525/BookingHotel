using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomEditHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1088f86a-f6f2-4cc8-88fa-1d0beb5e95d8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rooms",
                columns: new[] { "Id", "Description", "HotelId", "PeopleNumber", "RoomTypeId", "Square" },
                values: new object[,]
                {
                    { new Guid("6fd8b06f-ddbb-463f-8362-29cfbf272751"), "Nibh vero illum sit. Dolor consetetur tempor amet sea lorem consequat diam dolor ea accusam no te at ea clita diam.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("4776d7ce-cc8d-4c86-8b9d-40650651df33"), 34.0 },
                    { new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6"), "Takimata consectetuer lorem facilisis ipsum nibh sit accusam aliquyam justo clita", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("0282be52-3816-401e-af3f-074be089d921"), 40.0 },
                    { new Guid("c9153fe4-cb5d-4a77-9f63-7b1dd34c7bf7"), "Elitr sed enim stet dolore consectetuer consetetur et facer diam eirmod dolores tempor ea sit.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 4, new Guid("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"), 52.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6fd8b06f-ddbb-463f-8362-29cfbf272751"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c9153fe4-cb5d-4a77-9f63-7b1dd34c7bf7"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rooms",
                columns: new[] { "Id", "Description", "HotelId", "PeopleNumber", "RoomTypeId", "Square" },
                values: new object[,]
                {
                    { new Guid("1088f86a-f6f2-4cc8-88fa-1d0beb5e95d8"), "Nibh vero illum sit. Dolor consetetur tempor amet sea lorem consequat diam dolor ea accusam no te at ea clita diam.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("4776d7ce-cc8d-4c86-8b9d-40650651df33"), 34.0 },
                    { new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b"), "Takimata consectetuer lorem facilisis ipsum nibh sit accusam aliquyam justo clita", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("0282be52-3816-401e-af3f-074be089d921"), 40.0 },
                    { new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"), "Elitr sed enim stet dolore consectetuer consetetur et facer diam eirmod dolores tempor ea sit.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 4, new Guid("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"), 52.0 }
                });
        }
    }
}
