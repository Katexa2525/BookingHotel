using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomTypeEditModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                schema: "dbo",
                table: "HotelFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelPhotos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelUsefulInfos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelUsefulInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Hotels_HotelId",
                schema: "dbo",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_RoomTypes_RoomTypeId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Prices_RoomTypeId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                schema: "dbo",
                table: "HotelFacilities",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPhotos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelPhotos",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUsefulInfos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelUsefulInfos",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Hotels_HotelId",
                schema: "dbo",
                table: "Locations",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                schema: "dbo",
                table: "Reviews",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                schema: "dbo",
                table: "HotelFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelPhotos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelUsefulInfos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelUsefulInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Hotels_HotelId",
                schema: "dbo",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomTypeId",
                schema: "dbo",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_RoomTypeId",
                schema: "dbo",
                table: "Prices",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelFacilities_Hotels_HotelId",
                schema: "dbo",
                table: "HotelFacilities",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelPhotos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelPhotos",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelUsefulInfos_Hotels_HotelId",
                schema: "dbo",
                table: "HotelUsefulInfos",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Hotels_HotelId",
                schema: "dbo",
                table: "Locations",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_RoomTypes_RoomTypeId",
                schema: "dbo",
                table: "Prices",
                column: "RoomTypeId",
                principalSchema: "dbo",
                principalTable: "RoomTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Hotels_HotelId",
                schema: "dbo",
                table: "Reviews",
                column: "HotelId",
                principalSchema: "dbo",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
