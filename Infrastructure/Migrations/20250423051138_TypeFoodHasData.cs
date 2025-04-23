using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeFoodHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TypeFoods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0"), "Завтрак" },
                    { new Guid("4d53a1ed-9613-4406-8a31-a411c934e628"), "Полупансион" },
                    { new Guid("b2d7509e-c5b3-4936-8deb-26e51052446f"), "Завтрак, обед и ужин" },
                    { new Guid("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd"), "Без питания" },
                    { new Guid("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782"), "Всё включено" },
                    { new Guid("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"), "Завтрак" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("4d53a1ed-9613-4406-8a31-a411c934e628"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("b2d7509e-c5b3-4936-8deb-26e51052446f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TypeFoods",
                keyColumn: "Id",
                keyValue: new Guid("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"));
        }
    }
}
