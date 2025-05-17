using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyHasDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Currencies",
                columns: new[] { "Id", "Cur_Abbreviation", "Cur_Code", "Cur_DateEnd", "Cur_DateStart", "Cur_ID", "Cur_Name", "Cur_NameMulti", "Cur_Name_Bel", "Cur_Name_BelMulti", "Cur_Name_Eng", "Cur_Name_EngMulti", "Cur_ParentID", "Cur_Periodicity", "Cur_QuotName", "Cur_QuotName_Bel", "Cur_QuotName_Eng", "Cur_Scale", "Name" },
                values: new object[] { new Guid("232ba1bd-0192-4e35-b4a2-908dd61ea5cc"), "BYN", "933", new DateTime(2050, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9333, "Белорусский рубль", "Белорусский рублей", "Берарускі рубель", "Беларускіх рублёў", "BYN", "Belorussian Rubles", 9333, 0, "1 Белорусский рубль", "1 Беларускі рубель", "1 BYN", 1, "BYN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("232ba1bd-0192-4e35-b4a2-908dd61ea5cc"));
        }
    }
}
