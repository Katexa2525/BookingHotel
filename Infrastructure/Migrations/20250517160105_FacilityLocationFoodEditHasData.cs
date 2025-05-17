using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FacilityLocationFoodEditHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("3e67a939-ef3d-4b29-ac4e-856d9db456be"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("d95e677e-9e2e-4534-bfe4-0c26d2602973"));

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
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("19231977-a4b6-4925-93de-5b7674df7c2f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a1cad93e-020d-4ad0-b924-ec40782c7c45"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("d347a13c-c8cb-494a-8a1c-79400b256736"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Foods",
                columns: new[] { "Id", "HotelId", "Name", "TypeFoodId" },
                values: new object[,]
                {
                    { new Guid("00c01554-ddcb-4e68-a830-338742c458cc"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Полупансион", new Guid("4d53a1ed-9613-4406-8a31-a411c934e628") },
                    { new Guid("f7683dd2-73c0-4b87-b4f4-258c96632b95"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Завтрак", new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0") }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HotelFacilities",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("3ace774a-94b2-4892-9071-3cf1bb24482b"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Wi-Fi" },
                    { new Guid("5373222b-4390-4307-adec-3dae329a8617"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Оплата картой" },
                    { new Guid("faef5433-37dd-4d7f-9a88-4b77fc3ef63c"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Парковка" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Locations",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("80e707d6-f4b4-46fa-a5ea-5a82b7a17749"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "350 м до центра" },
                    { new Guid("b1c79ebc-d7c5-474f-84e1-8f824bbffdc6"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «ЦКР» 350 м" },
                    { new Guid("f4014f30-c06b-480e-b8cd-13b77320d07c"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «Главная городская площадь» 106 м" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("00c01554-ddcb-4e68-a830-338742c458cc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Foods",
                keyColumn: "Id",
                keyValue: new Guid("f7683dd2-73c0-4b87-b4f4-258c96632b95"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("3ace774a-94b2-4892-9071-3cf1bb24482b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("5373222b-4390-4307-adec-3dae329a8617"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "HotelFacilities",
                keyColumn: "Id",
                keyValue: new Guid("faef5433-37dd-4d7f-9a88-4b77fc3ef63c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("80e707d6-f4b4-46fa-a5ea-5a82b7a17749"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("b1c79ebc-d7c5-474f-84e1-8f824bbffdc6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f4014f30-c06b-480e-b8cd-13b77320d07c"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Foods",
                columns: new[] { "Id", "HotelId", "Name", "TypeFoodId" },
                values: new object[,]
                {
                    { new Guid("3e67a939-ef3d-4b29-ac4e-856d9db456be"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Завтрак", new Guid("072fc618-8703-437f-9662-5ba97d0ab4f0") },
                    { new Guid("d95e677e-9e2e-4534-bfe4-0c26d2602973"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Полупансион", new Guid("4d53a1ed-9613-4406-8a31-a411c934e628") }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HotelFacilities",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("3c546736-f3cb-4502-80f9-75543bebf5fb"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Парковка" },
                    { new Guid("828e84e6-ba0c-4e50-8be6-7c58c33be64b"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Оплата картой" },
                    { new Guid("839de6a2-33f1-4737-b4f8-a3ab2a7d62c9"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Wi-Fi" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Locations",
                columns: new[] { "Id", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("19231977-a4b6-4925-93de-5b7674df7c2f"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "350 м до центра" },
                    { new Guid("a1cad93e-020d-4ad0-b924-ec40782c7c45"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «ЦКР» 350 м" },
                    { new Guid("d347a13c-c8cb-494a-8a1c-79400b256736"), new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ост. «Главная городская площадь» 106 м" }
                });
        }
    }
}
