using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HotelReviewHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Reviews",
                columns: new[] { "Id", "DateTimeReview", "Description", "HotelId", "Name", "Star" },
                values: new object[,]
                {
                    { new Guid("2548903b-fb03-470d-acb2-97433a9f3dc6"), new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Были проездом и останавливались в отеле на две ночи в номере полулюкс. Что понравилось: отзывчивый персонал, чистый номер, вкусные завтрак, обед, и ужин. Порции смело можно делить на двоих), по вкусу как домашняя еда. Подаётся по времени, которое вы сами выбираете. Из необходимого в номере все есть чайник, стаканы, халаты, принадлежности для душа. В коридоре кулер с водой. Для курящих можно курить на пожарной лестнице не спускаясь вниз. Матрац хоть и немного усталый, но удобный. Заказали стирку и глажку одежды, все сделали аккуратно, принесли в номер на плечиках. В номере есть телефон можно связаться с персоналом, если возникают какие-то вопросы. Из минусов: почему полулюкс на третьем этаже? После долгой дороги очень некомфортно тащить чемоданы так высоко. Замок на двери в душевую с туалетом заедал и приходилось приноравливаться, чтобы его открыть, причем эта проблема возникала только изнутри помещения. Но самый большой минус это кондиционер, который дул четко на кровать, как его не настраивай. И ещё, о том что завтрак, обед и вечером ужин надо заказывать заранее, за день до заселения я вычитала в таком же отзыве. Считаю, что данную информацию отель должен вывешивать на своем сайте. Но все же положительных впечатлений больше чем отрицательных. Отель рекомендую для транзитных поездок.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "BlackAbaddon", 4 },
                    { new Guid("29a0c156-e40a-4d7a-b6d1-3aa1ca762acf"), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Все понравилось, чисто, тихо. Брали люкс. Большой двухкомнатный номер за приемлемую цену. Вежливый приятный персонал. Брали дополнительно комплексный завтрак, тоже понравился. Молодцы", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "KATERINA", 5 },
                    { new Guid("8f87b8fc-143f-4ace-8aba-6adb6000bceb"), new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отель на 3 звездочки. Если сейчас не начать заниматься сервисом, то можно скатиться в самый низ. После 21:00 начинаются стуканья в дверь, горничные ходят то халат занести (который не просили), то полотенца у них высохли, тоже надо заглянуть.", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Надежда Долиновская", 3 },
                    { new Guid("bbfe439b-d3f0-4c2a-9774-01482906d4f1"), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Прекрасная гостиница,чистые номера и постельное,отмечу сразу очень хорошие,вкусные и сытные завтраки. Так же когда заказывала еду в номер вкусно и порции как дома у мамы🔥 Когда выезжали мы забыли там документы на автомобиль и еще кое-какие личные вещи,я позвонила спустя день ,все вещи были на ресепшене спасибо всему персоналу за вашу работу. ", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "ольга шевченко", 5 },
                    { new Guid("c5102ee7-5f7a-4eb3-aa88-52b0923235ef"), new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Очень уютный отель. За свою цену более чем достаточно", new Guid("b3c83220-d255-46d7-ac76-114ece1d925a"), "Ромка Тарасов", 4 },
                    { new Guid("c6ea5eb4-fbce-47a3-9442-c59b0530a6ff"), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Жарко и душно, фанкойл не влияет на температуру, если приоткрыть окно, то из за общей вытяжки сильный свист в щели двери, по этой же причине открыть входную дверь в отель невозможно без серьёзного усилия. В №521 вода в душевой не уходит, и дело в наклоне чаши против слива. Просили при уборке убирать воду, но горничная этого не делала, пришлось ловить горничную на этаже. За 4 дня один раз убрались. ", new Guid("2cedea9f-912d-48c7-9125-3c11769f71a7"), "алыкса сочи", 2 },
                    { new Guid("ee1ae40e-1a41-4d51-8d23-8d8dbe1f7f55"), new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хороший уютный отель, приятный персонал, отель находится в 10 минутах ходьбы (или одна остановка на автобусе или троллейбусе) от железнодорожного вокзала. В номере есть всё необходимое: халат, тапочки, мыльные принадлежности, чайник кофе,чай, сахар (правда почему-то чайные ложки пластиковые, но из хорошего пластика).", new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "Александр Никольский", 5 },
                    { new Guid("f6311acc-d059-4c76-8927-cb743e5b5930"), new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отель хороший, комфортный, есть холодильник в номерах, сейф, удобный диван и стол для работы/еды. 4 звёзды поставил в связи с несколькими причинами: заезжало в номер два человека, всё оставили на двоих, а халат только один, ну как так... душевая очень странного стиля - 1.5 метра стекла отделяет душ от самой ванной комнаты, вход без какой-либо дверцы или подвижной стенки, в следствии чего у любителей держать душ в руках во время купания пол в ванной будет заливать от брызг, что однозначно не радует.", new Guid("ffe1c64a-ad2b-443e-b5ac-2ce60eca6340"), "Ibn Minaev", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("2548903b-fb03-470d-acb2-97433a9f3dc6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("29a0c156-e40a-4d7a-b6d1-3aa1ca762acf"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8f87b8fc-143f-4ace-8aba-6adb6000bceb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bbfe439b-d3f0-4c2a-9774-01482906d4f1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("c5102ee7-5f7a-4eb3-aa88-52b0923235ef"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("c6ea5eb4-fbce-47a3-9442-c59b0530a6ff"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ee1ae40e-1a41-4d51-8d23-8d8dbe1f7f55"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f6311acc-d059-4c76-8927-cb743e5b5930"));
        }
    }
}
