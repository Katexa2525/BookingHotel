using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyRoomModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Currencies_CurrencyId1",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                schema: "dbo",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                schema: "dbo",
                table: "RoomPhotos");

            migrationBuilder.DropIndex(
                name: "IX_Prices_CurrencyId1",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "CurrencyId1",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                schema: "dbo",
                table: "Prices",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                schema: "dbo",
                table: "RoomFacilities",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                schema: "dbo",
                table: "RoomPhotos",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                schema: "dbo",
                table: "RoomFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                schema: "dbo",
                table: "RoomPhotos");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId1",
                schema: "dbo",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CurrencyId1",
                schema: "dbo",
                table: "Prices",
                column: "CurrencyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Currencies_CurrencyId1",
                schema: "dbo",
                table: "Prices",
                column: "CurrencyId1",
                principalSchema: "dbo",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                schema: "dbo",
                table: "Prices",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFacilities_Rooms_RoomId",
                schema: "dbo",
                table: "RoomFacilities",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                schema: "dbo",
                table: "RoomPhotos",
                column: "RoomId",
                principalSchema: "dbo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
