using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HotelLocationHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Locations",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("19231977-a4b6-4925-93de-5b7674df7c2f"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "350 м до центра" },
                    { new Guid("646f990a-81a2-425c-9016-428db3d58fd8"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "8,6 км до центра" },
                    { new Guid("7d2a919d-e7d5-435a-ae0a-592037d489e3"), new Guid("2cedea9f-912d-48c7-9125-3c11769f71a7"), "ост. «Реликтовый лес» 960 м" },
                    { new Guid("8c0b9fdd-209a-4e07-babb-c32f6308a25f"), new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "2 км до футбольного стадиона" },
                    { new Guid("a1cad93e-020d-4ad0-b924-ec40782c7c45"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «ЦКР» 350 м" },
                    { new Guid("bc2e63b0-8b5c-4ea6-bf47-48f5767705c9"), new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "1 км до центра" },
                    { new Guid("d347a13c-c8cb-494a-8a1c-79400b256736"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «Главная городская площадь» 106 м" },
                    { new Guid("d89fbcd6-8ea5-4e6a-bc2a-690b9a5cf23a"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Площадь Тукая 1 км" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("19231977-a4b6-4925-93de-5b7674df7c2f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("646f990a-81a2-425c-9016-428db3d58fd8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("7d2a919d-e7d5-435a-ae0a-592037d489e3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("8c0b9fdd-209a-4e07-babb-c32f6308a25f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a1cad93e-020d-4ad0-b924-ec40782c7c45"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("bc2e63b0-8b5c-4ea6-bf47-48f5767705c9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("d347a13c-c8cb-494a-8a1c-79400b256736"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("d89fbcd6-8ea5-4e6a-bc2a-690b9a5cf23a"));
        }
    }
}
