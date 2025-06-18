using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReviewAddField_UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("311d11ba-0db1-479d-b630-e605a2fc7da2"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("56ab0d5b-75ea-4fa7-89b9-caedf1047e1d"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("7891815c-559c-4d88-8ec0-48f1de339c5f"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8d7ad3f8-748c-40f3-a70a-6c3c0654d224"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("b621a29b-c219-473e-8c75-49df2ce03448"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("c6ea5eb4-fbce-47a3-9442-c59b0530a6ff"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ee1ae40e-1a41-4d51-8d23-8d8dbe1f7f55"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f6311acc-d059-4c76-8927-cb743e5b5930"),
                column: "UserId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Reviews");
        }
    }
}
