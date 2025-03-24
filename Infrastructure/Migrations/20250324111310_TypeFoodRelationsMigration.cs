using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeFoodRelationsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_TypeFoods_TypeFoodId",
                schema: "dbo",
                table: "Foods");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_TypeFoods_TypeFoodId",
                schema: "dbo",
                table: "Foods",
                column: "TypeFoodId",
                principalSchema: "dbo",
                principalTable: "TypeFoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_TypeFoods_TypeFoodId",
                schema: "dbo",
                table: "Foods");

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
    }
}
