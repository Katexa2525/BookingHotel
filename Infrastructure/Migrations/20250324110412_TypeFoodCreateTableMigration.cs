using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeFoodCreateTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeFoods",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFoods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_TypeFoodId",
                schema: "dbo",
                table: "Foods",
                column: "TypeFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_TypeFoods_TypeFoodId",
                schema: "dbo",
                table: "Foods",
                column: "TypeFoodId",
                principalSchema: "dbo",
                principalTable: "TypeFoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_TypeFoods_TypeFoodId",
                schema: "dbo",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "TypeFoods",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Foods_TypeFoodId",
                schema: "dbo",
                table: "Foods");
        }
    }
}
