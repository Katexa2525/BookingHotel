using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HotelFacilityHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HotelFacilities",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("2ab2e0bc-e522-4b82-a85d-8a2afd8b589d"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Парковка" },
                    { new Guid("3c546736-f3cb-4502-80f9-75543bebf5fb"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Парковка" },
                    { new Guid("828e84e6-ba0c-4e50-8be6-7c58c33be64b"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Оплата картой" },
                    { new Guid("839de6a2-33f1-4737-b4f8-a3ab2a7d62c9"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Wi-Fi" },
                    { new Guid("878da153-3a2a-492f-8391-819b6011f460"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Тренажёрный зал" },
                    { new Guid("93124016-d871-4999-b3ca-bb1d592743f3"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Оплата картой" },
                    { new Guid("ac6eb263-ec82-432d-89ef-043cb803948f"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Wi-Fi" },
                    { new Guid("cafbc71d-e834-462b-bc1d-b81954014516"), new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Бассейн" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("2ab2e0bc-e522-4b82-a85d-8a2afd8b589d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("3c546736-f3cb-4502-80f9-75543bebf5fb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("828e84e6-ba0c-4e50-8be6-7c58c33be64b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("839de6a2-33f1-4737-b4f8-a3ab2a7d62c9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("878da153-3a2a-492f-8391-819b6011f460"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("93124016-d871-4999-b3ca-bb1d592743f3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("ac6eb263-ec82-432d-89ef-043cb803948f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("cafbc71d-e834-462b-bc1d-b81954014516"));
        }
    }
}
