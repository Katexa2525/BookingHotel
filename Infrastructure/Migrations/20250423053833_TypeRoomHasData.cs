using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeRoomHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0282be52-3816-401e-af3f-074be089d921"), "Студия" },
                    { new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0"), "Полулюкс" },
                    { new Guid("0f4ef0eb-7f4d-4a8b-94c6-6d9f7e0b8c0d"), "Двухкомнатный Полулюкс" },
                    { new Guid("109d81b2-58b8-4f48-aa96-469b1e9dd445"), "Двухкомнатный Люкс" },
                    { new Guid("32de15de-509d-46ff-8c5a-baf5cdc34405"), "Президентский люкс" },
                    { new Guid("3ca90fe7-2be3-4d2b-893c-329e78f1795b"), "Номер Стандарт" },
                    { new Guid("4776d7ce-cc8d-4c86-8b9d-40650651df33"), "Стандарт Бизнес" },
                    { new Guid("4f9a65f2-de87-46b4-9860-e7c0262c92d9"), "Улучшенные двухкомнатные апартаменты" },
                    { new Guid("5046fcc4-fbef-49f1-b2f5-b5c64e380ea0"), "Двухкомнатные апартаменты с одной спальней" },
                    { new Guid("5afb6d3d-0ce3-4c34-a988-35187ffdf877"), "Люкс двухкомнатный 8-ми местный" },
                    { new Guid("68188476-48c6-48be-b4cc-f8b63b4f0b08"), "Номер Делюкс" },
                    { new Guid("805175af-552e-4b6c-b3fd-5a49c3a226d8"), "Трехкомнатные апартаменты с одной спальней" },
                    { new Guid("91ed5eb9-d369-4788-bcdc-7bbaf1813a2a"), "Номер «Восточный»" },
                    { new Guid("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"), "Люкс Гранд Премиум" },
                    { new Guid("de0f70a9-b924-47ed-a599-295a4e8b4889"), "Стандарт Бизнес (четырехместный )" },
                    { new Guid("ebf1c674-191c-4d27-ab38-aad7f7360c17"), "Стандарт 3-х местный" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("0282be52-3816-401e-af3f-074be089d921"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f4ef0eb-7f4d-4a8b-94c6-6d9f7e0b8c0d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("109d81b2-58b8-4f48-aa96-469b1e9dd445"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("32de15de-509d-46ff-8c5a-baf5cdc34405"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("3ca90fe7-2be3-4d2b-893c-329e78f1795b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("4776d7ce-cc8d-4c86-8b9d-40650651df33"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f9a65f2-de87-46b4-9860-e7c0262c92d9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("5046fcc4-fbef-49f1-b2f5-b5c64e380ea0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("5afb6d3d-0ce3-4c34-a988-35187ffdf877"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("68188476-48c6-48be-b4cc-f8b63b4f0b08"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("805175af-552e-4b6c-b3fd-5a49c3a226d8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("91ed5eb9-d369-4788-bcdc-7bbaf1813a2a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("de0f70a9-b924-47ed-a599-295a4e8b4889"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: new Guid("ebf1c674-191c-4d27-ab38-aad7f7360c17"));
        }
    }
}
