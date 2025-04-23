using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Currency_Rate_Modification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cur_Abbreviation",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_Code",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Cur_DateEnd",
                schema: "dbo",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Cur_DateStart",
                schema: "dbo",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Cur_ID",
                schema: "dbo",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cur_Name",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_NameMulti",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_Name_Bel",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_Name_BelMulti",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_Name_Eng",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_Name_EngMulti",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Cur_ParentID",
                schema: "dbo",
                table: "Currencies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cur_Periodicity",
                schema: "dbo",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cur_QuotName",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_QuotName_Bel",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cur_QuotName_Eng",
                schema: "dbo",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Cur_Scale",
                schema: "dbo",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Currencies_Cur_ID",
                schema: "dbo",
                table: "Currencies",
                column: "Cur_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Currencies_Cur_ID",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Abbreviation",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Code",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_DateEnd",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_DateStart",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_ID",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Name",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_NameMulti",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Name_Bel",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Name_BelMulti",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Name_Eng",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Name_EngMulti",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_ParentID",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Periodicity",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_QuotName",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_QuotName_Bel",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_QuotName_Eng",
                schema: "dbo",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Cur_Scale",
                schema: "dbo",
                table: "Currencies");
        }
    }
}
