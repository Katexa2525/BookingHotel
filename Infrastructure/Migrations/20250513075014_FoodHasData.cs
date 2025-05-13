using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FoodHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Foods",
                columns: new[] { "Id", "HotelId", "Name", "TypeFoodId" },
                values: new object[,]
                {
                    { new Guid("00f7e7f9-387c-47f3-a728-cf91782f6ee3"), new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "Без питания", new Guid("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd") },
                    { new Guid("0375cbb1-a4c1-42bf-b4ff-46a70d5ca365"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Завтрак, обед и ужин", new Guid("b2d7509e-c5b3-4936-8deb-26e51052446f") },
                    { new Guid("3e67a939-ef3d-4b29-ac4e-856d9db456be"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Завтрак", new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0") },
                    { new Guid("4321b0f8-fa4b-447f-91b0-89d119e02977"), new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "Всё включено", new Guid("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782") },
                    { new Guid("7dbfc4df-a227-4ddb-87c0-011a057b4403"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Завтрак полноценный", new Guid("e0a5a158-5ef8-414c-896a-49fdf04dc7a4") },
                    { new Guid("d95e677e-9e2e-4534-bfe4-0c26d2602973"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Полупансион", new Guid("4d53a1ed-9613-4406-8a31-a411c934e628") }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"),
                column: "Name",
                value: "Завтрак полноценный");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("00f7e7f9-387c-47f3-a728-cf91782f6ee3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("0375cbb1-a4c1-42bf-b4ff-46a70d5ca365"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("3e67a939-ef3d-4b29-ac4e-856d9db456be"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("4321b0f8-fa4b-447f-91b0-89d119e02977"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("7dbfc4df-a227-4ddb-87c0-011a057b4403"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("d95e677e-9e2e-4534-bfe4-0c26d2602973"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"),
                column: "Name",
                value: "Завтрак");
        }
    }
}
