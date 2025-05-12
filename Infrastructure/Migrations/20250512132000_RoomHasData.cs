using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rooms",
                columns: new[] { "Id", "Description", "HotelId", "PeopleNumber", "RoomTypeId", "Square" },
                values: new object[,]
                {
                    { new Guid("1088f86a-f6f2-4cc8-88fa-1d0beb5e95d8"), "Nibh vero illum sit. Dolor consetetur tempor amet sea lorem consequat diam dolor ea accusam no te at ea clita diam.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("4776d7ce-cc8d-4c86-8b9d-40650651df33"), 34.0 },
                    { new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b"), "Takimata consectetuer lorem facilisis ipsum nibh sit accusam aliquyam justo clita", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 2, new Guid("0282be52-3816-401e-af3f-074be089d921"), 40.0 },
                    { new Guid("9d551953-1b52-4cb1-ad90-31c8653955fa"), "Zzril tation clita stet.", new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), 3, new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0"), 38.0 },
                    { new Guid("dca48ffc-c572-4ca5-8217-7a7d370fed2a"), "Accumsan amet nonumy nonumy et amet euismod sed ipsum invidunt tincidunt ad. Ea dolor justo diam. Sea at labore duo iriure et ut ullamcorper in dignissim sit sit ipsum.", new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), 3, new Guid("68188476-48c6-48be-b4cc-f8b63b4f0b08"), 40.5 },
                    { new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"), "Elitr sed enim stet dolore consectetuer consetetur et facer diam eirmod dolores tempor ea sit.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), 4, new Guid("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"), 52.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("9d551953-1b52-4cb1-ad90-31c8653955fa"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dca48ffc-c572-4ca5-8217-7a7d370fed2a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));
        }
    }
}
