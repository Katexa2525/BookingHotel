using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomFacilityEditHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("4c17ade5-2349-43fe-a9d1-d10aed6ddebd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("6e69e113-eb98-4094-b417-83d61a9ab4eb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("d3fb6a18-f736-4cb5-bf64-69c36b3d489c"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("13b17dab-7ed0-40d9-93d5-b020eea0aad9"),
                column: "RoomId",
                value: new Guid("c9153fe4-cb5d-4a77-9f63-7b1dd34c7bf7"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("427ba46a-07e6-4da2-afed-c1760f02a636"),
                column: "RoomId",
                value: new Guid("c9153fe4-cb5d-4a77-9f63-7b1dd34c7bf7"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("573716d8-e318-4ba0-957c-2a1a0be4af30"),
                column: "RoomId",
                value: new Guid("6fd8b06f-ddbb-463f-8362-29cfbf272751"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("a774e890-3726-4e5b-8071-50e01f27b7b9"),
                column: "RoomId",
                value: new Guid("6fd8b06f-ddbb-463f-8362-29cfbf272751"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoomFacilities",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("572b5bb5-6254-4611-b57a-93f546fb62af"), "Цифровое ТВ", new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6") },
                    { new Guid("a5d60b40-0270-4b9d-b559-161efd8b6f86"), "Wi-Fi", new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6") },
                    { new Guid("fe5c4f20-89f9-4e2a-ba51-dccfa75ebe5b"), "Мини-холодильник", new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("572b5bb5-6254-4611-b57a-93f546fb62af"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("a5d60b40-0270-4b9d-b559-161efd8b6f86"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("fe5c4f20-89f9-4e2a-ba51-dccfa75ebe5b"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("13b17dab-7ed0-40d9-93d5-b020eea0aad9"),
                column: "RoomId",
                value: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("427ba46a-07e6-4da2-afed-c1760f02a636"),
                column: "RoomId",
                value: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("573716d8-e318-4ba0-957c-2a1a0be4af30"),
                column: "RoomId",
                value: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "RoomFacilities",
                keyColumn: "Id",
                keyValue: new Guid("a774e890-3726-4e5b-8071-50e01f27b7b9"),
                column: "RoomId",
                value: new Guid("e12d0ba1-7ac8-4a19-b241-31705c2a3500"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoomFacilities",
                columns: new[] { "Id", "Name", "RoomId" },
                values: new object[,]
                {
                    { new Guid("4c17ade5-2349-43fe-a9d1-d10aed6ddebd"), "Цифровое ТВ", new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b") },
                    { new Guid("6e69e113-eb98-4094-b417-83d61a9ab4eb"), "Мини-холодильник", new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b") },
                    { new Guid("d3fb6a18-f736-4cb5-bf64-69c36b3d489c"), "Wi-Fi", new Guid("6b09f078-169f-4ae8-aaa1-5b8a2e1c896b") }
                });
        }
    }
}
