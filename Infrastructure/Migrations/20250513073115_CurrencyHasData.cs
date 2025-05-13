using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Currencies",
                columns: new[] { "Id", "Cur_Abbreviation", "Cur_Code", "Cur_DateEnd", "Cur_DateStart", "Cur_ID", "Cur_Name", "Cur_NameMulti", "Cur_Name_Bel", "Cur_Name_BelMulti", "Cur_Name_Eng", "Cur_Name_EngMulti", "Cur_ParentID", "Cur_Periodicity", "Cur_QuotName", "Cur_QuotName_Bel", "Cur_QuotName_Eng", "Cur_Scale", "Name" },
                values: new object[,]
                {
                    { new Guid("abbe09fc-5e77-414c-8940-e77e934de88f"), "RUB", "643", new DateTime(2050, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 456, "Российский рубль", "Российских рублей", "Расійскі рубель", "Расійскіх рублёў", "Russian Ruble", "Russian Rubles", 190, 0, "100 Российских рублей", "100 Расійскіх рублёў", "100 Russian Rubles", 100, "RUB" },
                    { new Guid("f3524eff-e305-4305-8ae3-2731ad415fe9"), "EUR", "978", new DateTime(2050, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 451, "Евро", "Евро", "Еўра", "Еўра", "Euro", "Euros", 19, 0, "1 Евро", "1 Еўра", "1 Euro", 1, "EUR" },
                    { new Guid("f3ca1c7b-c275-4feb-9790-9a42efb878ee"), "USD", "840", new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 145, "Доллар США", "Долларов США", "Долар ЗША", "Долараў ЗША", "US Dollar", "US Dollars", 145, 0, "1 Доллар США", "1 Долар ЗША", "1 US Dollar", 1, "USD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("abbe09fc-5e77-414c-8940-e77e934de88f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f3524eff-e305-4305-8ae3-2731ad415fe9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f3ca1c7b-c275-4feb-9790-9a42efb878ee"));
        }
    }
}
