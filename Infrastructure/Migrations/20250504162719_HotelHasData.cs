using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HotelHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Hotels",
                columns: new[] { "Id", "Description", "Location", "MainPhoto", "Name", "Rating", "Star" },
                values: new object[,]
                {
                    { new Guid("2cedea9f-912d-48c7-9125-3c11769f71a7"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut laoreet, justo ut egestas pulvinar, est dui elementum neque, ac elementum lectus tellus in libero. Cras ullamcorper tellus id velit finibus, at rutrum odio convallis. Donec gravida nec mauris eget iaculis. Praesent faucibus ante fringilla, ullamcorper enim sit amet, suscipit leo. Sed libero erat, facilisis vel nunc et, venenatis volutpat quam. Integer sit amet lobortis risus, ut hendrerit orci. Vivamus pulvinar lectus dui, a dictum odio eleifend vitae. Pellentesque gravida risus eu ipsum efficitur consectetur. Nulla lectus leo, pharetra vel ante ut, mollis pharetra arcu. Morbi vitae metus ante. Integer lacinia.", "Gearstones, UK", "2CEDEA9F-912D-48C7-9125-3C11769F71A7.jpg", "Hotel, Building, House, Shops", 4.7999999999999998, 5 },
                    { new Guid("6c294357-66e3-49b1-ab63-42173553e89c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer facilisis magna eget sem feugiat, non pulvinar dui interdum. Proin quis tincidunt ex. Pellentesque dictum nibh dolor, cursus porta magna sodales a. Morbi vitae tortor nisi. Nullam molestie dui tempus, lobortis dolor sit amet, hendrerit libero. Quisque sed massa id lacus ornare faucibus eget facilisis mi. Donec interdum bibendum leo nec facilisis. In semper nec eros id tincidunt. Nunc sed sagittis justo. Ut massa ligula, posuere sed iaculis sit amet, laoreet ut ipsum. Nulla facilisi. Vestibulum iaculis risus nulla. Nunc congue elit et erat blandit vulputate. Praesent vulputate tortor at augue.", "Ockle, Scotland", "", "Hotel, Winter, Season", 3.6000000000000001, 4 },
                    { new Guid("95175bfc-af50-4588-9373-68ee30e88f75"), "Lorem ipsum dolor sit amet gubergren ipsum vulputate invidunt vel sit dolor liber. Elitr ut et vulputate est. Justo ut nonummy est. Dolor ipsum duis rebum lorem laoreet autem elitr vero gubergren sea est clita wisi et dolore. Ut duo lorem ipsum takimata facilisis est sanctus sea at accusam sanctus clita labore et dolor. Eos illum delenit et ipsum sed amet. Gubergren accusam consetetur.", "Paris, France", "", "Hotel, Invalidendom", 4.9000000000000004, 5 },
                    { new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla volutpat orci at augue ultricies fermentum. Ut massa lectus, dignissim sed molestie ut, viverra vel diam. Fusce at iaculis magna. Suspendisse vel est et est luctus ornare venenatis ut neque. Pellentesque varius lacus sed arcu pellentesque, a porttitor velit gravida. Nunc nunc lectus, rhoncus consectetur metus eget, fermentum laoreet mauris. Cras ac gravida ante. Ut in ante ex. Proin tristique a ligula vel pharetra. Vestibulum blandit nisl dui, in pulvinar metus mollis pharetra. Duis cursus porttitor libero, quis lacinia velit. Curabitur tincidunt laoreet mi, eu maximus nibh vestibulum sed. Phasellus orci.", "Durbach, Germany", "B3C83220-D255-46D7-AC76-114ECE1D925A.jpg", "Hotel, Singapore, Fullerton bay", 4.9000000000000004, 3 },
                    { new Guid("c48cbbe7-6a94-4480-9c60-48b54af81545"), "Singapore skyline with urban buildings over water", "Ocluder, Singopour", "", "Marina bay sands, Singapore", 4.2000000000000002, 5 },
                    { new Guid("e0c80aaf-2224-40d5-8d54-66bf4fbbfcd8"), "Lorem ipsum dolor sit amet sed diam sadipscing sit stet amet invidunt nibh autem voluptua justo tempor tation sed. Consetetur labore accusam ut nonumy justo dolore kasd. Duis odio labore dolore stet. Kasd vel dolor feugait illum accusam veniam dolore dignissim labore. Ut sed elitr elitr amet gubergren ipsum tempor sed duo erat justo no nibh id voluptua ut.", "Madrid, Espane", "E0C80AAF-2224-40D5-8D54-66BF4FBBFCD8.jpg", "Hotel, High, Stone image", 4.0999999999999996, 4 },
                    { new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus a semper lacus. Vestibulum vehicula elementum auctor. Vestibulum malesuada, nibh a pretium ullamcorper, tortor nisi tincidunt ante, sed gravida purus mi in ligula. In malesuada ligula vitae risus iaculis, et sollicitudin lorem ornare. Nullam nec ullamcorper est. Donec efficitur et ipsum auctor semper. In id eros risus. Suspendisse quis massa convallis, suscipit eros eget, ullamcorper metus. Phasellus laoreet nulla quam, vel porttitor diam efficitur vitae. Etiam sollicitudin urna vel auctor accumsan. Suspendisse commodo pulvinar mauris, quis viverra lectus hendrerit dictum. In sed lorem tempus ipsum rutrum suscipit vitae sed mauris. Nunc.", "Nottingham, UK", "F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308.jpg", "Hotel, Nature, Switzerland", 2.3999999999999999, 4 },
                    { new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut imperdiet ex ac euismod pulvinar. Cras lorem nulla, posuere sed semper sed, scelerisque non nulla. Sed mi lorem, condimentum nec magna ac, ultricies lobortis ante. Integer tincidunt, metus eget mattis hendrerit, nibh metus sagittis diam, sed imperdiet metus nisi ac magna. Pellentesque iaculis mi purus, a porta tortor sodales consequat. Pellentesque vel mattis ligula. Fusce ac massa id ex rutrum eleifend. Nunc porta tortor dictum, ornare metus quis, laoreet ante. Nullam ullamcorper magna eget eleifend consequat. In nulla ex, iaculis vestibulum eros ac, vestibulum euismod arcu. Nullam sollicitudin at neque et.", "Furna, Switzerland", "FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340.jpg", "Lanzarote, Hotel, Heaven", 4.7000000000000002, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("2cedea9f-912d-48c7-9125-3c11769f71a7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("6c294357-66e3-49b1-ab63-42173553e89c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("95175bfc-af50-4588-9373-68ee30e88f75"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("c48cbbe7-6a94-4480-9c60-48b54af81545"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e0c80aaf-2224-40d5-8d54-66bf4fbbfcd8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("f6a9207d-ad8b-4d5f-bea5-1cd2f87a0308"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"));
        }
    }
}
