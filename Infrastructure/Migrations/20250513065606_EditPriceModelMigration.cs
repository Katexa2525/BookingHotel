using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditPriceModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Hotels_HotelId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_RoomTypes_RoomTypeId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_HotelId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "HotelId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeId",
                schema: "dbo",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                schema: "dbo",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                schema: "dbo",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_RoomTypes_RoomTypeId",
                schema: "dbo",
                table: "Prices",
                column: "RoomTypeId",
                principalSchema: "dbo",
                principalTable: "RoomTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_RoomTypes_RoomTypeId",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "DateStart",
                schema: "dbo",
                table: "Prices");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoomTypeId",
                schema: "dbo",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                schema: "dbo",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prices_HotelId",
                schema: "dbo",
                table: "Prices",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Hotels_HotelId",
                schema: "dbo",
                table: "Prices",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
