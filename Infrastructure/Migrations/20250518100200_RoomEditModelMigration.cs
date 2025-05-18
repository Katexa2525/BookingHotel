using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomEditModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6fd8b06f-ddbb-463f-8362-29cfbf272751"),
                column: "MainPhoto",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9d551953-1b52-4cb1-ad90-31c8653955fa"),
                column: "MainPhoto",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bef53e26-c490-4fb6-89ca-d920efc982f6"),
                column: "MainPhoto",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c9153fe4-cb5d-4a77-9f63-7b1dd34c7bf7"),
                column: "MainPhoto",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dca48ffc-c572-4ca5-8217-7a7d370fed2a"),
                column: "MainPhoto",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPhoto",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
