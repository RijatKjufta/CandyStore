using Microsoft.EntityFrameworkCore.Migrations;

namespace Candystore.Data.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ApetisaniProduct", "Description", "imgURL" },
                values: new object[] { "Almonds", "Seeds for Joy", "almond-seeds.jpg" });

            migrationBuilder.UpdateData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ApetisaniProduct", "Description", "imgURL", "price" },
                values: new object[] { "Brazilian Nuts", "Seeds for Joy", "brazilian-nuts.jpg", 10.99 });

            migrationBuilder.InsertData(
                table: "Apetisani",
                columns: new[] { "ID", "ApetisaniProduct", "Description", "imgURL", "price" },
                values: new object[,]
                {
                    { 16, "Wallnuts", "Seeds for Joy", "wallnuts.jpg", 8.9900000000000002 },
                    { 15, "Sweet Peanuts", "Seeds for Joy", "sweet-peanuts.jpg", 5.9900000000000002 },
                    { 14, "Sweet Corn", "Seeds for Joy", "sweet-corn.jpg", 4.9900000000000002 },
                    { 13, "Sunflower Seeds", "Seeds for Joy", "sunflower-seeds.jpg ", 3.9900000000000002 },
                    { 12, "Red Pistachios", "Seeds for Joy", "red-pistacios.jpg ", 12.99 },
                    { 11, "Pumpkin Seeds", "Seeds for Joy", "pumpkin-seeds.jpg", 3.9900000000000002 },
                    { 3, "Chips Peanuts", "Seeds for Joy", "chips-peanuts.jpg", 4.9900000000000002 },
                    { 9, "Pistachios", "Seeds for Joy", "pistaccio.jpg", 9.9900000000000002 },
                    { 8, "Peanuts Covered", "Seeds for Joy", "peanuts-covered.jpg", 4.9900000000000002 },
                    { 7, "Peanuts", "Seeds for Joy", "peanuts.jpg", 4.9900000000000002 },
                    { 6, "Leblebi Sari", "Seeds for Joy", "leblebi-sari.jpg", 4.9900000000000002 },
                    { 5, "Indian Nuts", "Seeds for Joy", "indian-nuts.jpg", 10.99 },
                    { 4, "Hazelnuts", "Seeds for Joy", "hazelnuts.jpg", 9.9900000000000002 },
                    { 10, "Popcorn", "Seeds for Joy", "popcorn4_4bee.jpg", 2.9900000000000002 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "54becfae-9ed0-4cec-b62c-2272b222f579");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                column: "ConcurrencyStamp",
                value: "3c6ed0b3-d851-4839-aa9b-0dfa155c8eb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "949060b9-6c20-43fa-8876-d8476f16bc4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHQzRrI1rRIGYPsZDozf+52w4Ypmk9d4l89pObbAlgGnEwOPwLTx0oQiv3aigRT7zg==");

            migrationBuilder.UpdateData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CandyProduct", "Description", "imgURL", "price" },
                values: new object[] { "Bubble Bubble", "Sweat", "bubble-bubble.jpg", 5.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CandyProduct", "Description", "imgURL", "price" },
                values: new object[] { "Forrest Fruit Candies", "Sweat", "christmas-candycanes.jpg", 5.9900000000000002 });

            migrationBuilder.InsertData(
                table: "CandyTypes",
                columns: new[] { "ID", "CandyProduct", "Description", "imgURL", "price" },
                values: new object[,]
                {
                    { 9, "Christmas Candy", "Menthol and Sweet", "christmas-candycanes.jpg", 5.9900000000000002 },
                    { 3, "Fruit Sallad", "Sweat and Sour", "forrest-fruit-candy.jpg", 5.9900000000000002 },
                    { 4, "Forrest Fruit Candies", "Sweat", "fruit-salad-rock-candy.jpg", 5.9900000000000002 },
                    { 5, "Love Image Candies", "Sweat", "love-image-candy.jpg", 5.9900000000000002 },
                    { 6, "Mix Image Candies", "Sweat", "mix-hard-image-candy.jpg", 5.9900000000000002 },
                    { 7, "Ribbon Candies", "Sweat", "ribbon-candy.jpg", 5.9900000000000002 },
                    { 8, "Rock Candie", "Sweat", "rock-candy.png", 5.9900000000000002 }
                });

            migrationBuilder.UpdateData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "imgURL" },
                values: new object[] { "100% Arabica", "hausbrandt-academia.jpg" });

            migrationBuilder.UpdateData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CoffeProduct", "Description", "Price", "imgURL" },
                values: new object[] { "Amigos Blue", "100% Arabica", 15.99, "amigos-blue.jpeg" });

            migrationBuilder.InsertData(
                table: "CoffeTypes",
                columns: new[] { "ID", "CoffeProduct", "Description", "Price", "imgURL" },
                values: new object[,]
                {
                    { 4, "Auslesse", "100% Arabica", 15.99, "auslesse-caffe.png" },
                    { 5, "Boncampo", "100% Arabica", 15.99, "boncampo-clasic.jpg" },
                    { 12, "Illy Mocca", "100% Arabica", 25.989999999999998, "illy mocca.jpg" },
                    { 11, "Hausbraundt Espresso", "100% Arabica", 15.99, "hausbrandt-espresso.png" },
                    { 10, "Hausbraundt Black", "100% Arabica", 22.989999999999998, "hausbrandt-black.jpg" },
                    { 9, "Housbrandt Academia", "100% Arabica", 20.989999999999998, "hausbrandt-academia.jpg" },
                    { 8, "Frank", "100% Arabica", 19.989999999999998, "frank].png" },
                    { 3, "Amigos Light", "100% Arabica", 15.99, "amigos-light.jpeg" },
                    { 6, "Chicco D'Oro", "100% Arabica", 15.99, "chicco-doro.png" },
                    { 13, "Amigos", "80% Arabica 20% Robusta", 11.99, "amigos-red.jpeg" },
                    { 7, "Doncaffe", "100% Arabica", 15.99, "doncaffe.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ApetisaniProduct", "Description", "imgURL" },
                values: new object[] { "Semke", "dwkoap", null });

            migrationBuilder.UpdateData(
                table: "Apetisani",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ApetisaniProduct", "Description", "imgURL", "price" },
                values: new object[] { "Badem", "dkopwakf", null, 7.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "b48b4824-b483-4ccd-85e4-e2fe1febd6cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                column: "ConcurrencyStamp",
                value: "fc1cf696-2d7a-4d13-a610-8f4d08542dd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                column: "ConcurrencyStamp",
                value: "43ece639-d975-4a3d-8c1b-1d4e80f782c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG8eW9+4eAMNgZGTYarl2V+Fd1k4HHkGV/j7O/ITI8C//E7dOI2Atot01QsRXLXsvw==");

            migrationBuilder.UpdateData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CandyProduct", "Description", "imgURL", "price" },
                values: new object[] { "Lolipop", "dasd", null, 8.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "CandyTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CandyProduct", "Description", "imgURL", "price" },
                values: new object[] { "lizavce", "dkwopadk", null, 6.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "imgURL" },
                values: new object[] { "gedafa", null });

            migrationBuilder.UpdateData(
                table: "CoffeTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CoffeProduct", "Description", "Price", "imgURL" },
                values: new object[] { "Amigos", "jiodw", 11.99, null });
        }
    }
}
