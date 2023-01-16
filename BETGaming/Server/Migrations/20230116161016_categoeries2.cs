using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BETGaming.Server.Migrations
{
    /// <inheritdoc />
    public partial class categoeries2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 5, "Electronics", "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Price", "Title" },
                values: new object[,]
                {
                    { 5, 5, "The latest iPhone with a 6.1-inch Super Retina XDR display.", "https://example.com/iphone12.jpg", 799.00m, "Apple iPhone 12" },
                    { 6, 5, "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.", "https://example.com/samsungs21.jpg", 799.00m, "Samsung Galaxy S21" },
                    { 7, 5, "A budget-friendly phone from Google with a 5.8-inch OLED display.", "https://example.com/pixel4a.jpg", 349.00m, "Google Pixel 4a" },
                    { 8, 5, "A high-performance phone with a 6.55-inch Fluid AMOLED display.", "https://example.com/oneplus8t.jpg", 749.00m, "OnePlus 8T" },
                    { 9, 5, "The latest gaming console from Sony with 8K graphics and ray tracing.", "https://example.com/ps5.jpg", 499.00m, "Sony PlayStation 5" },
                    { 10, 5, "The latest gaming console from Microsoft with 4K graphics and 120fps.", "https://example.com/xboxseriesx.jpg", 499.00m, "Microsoft Xbox Series X" },
                    { 11, 5, "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.", "https://example.com/switch.jpg", 299.00m, "Nintendo Switch" },
                    { 12, 5, "A 4K OLED TV with AI ThinQ and Google Assistant built-in.", "https://example.com/lgoledcx.jpg", 1499.00m, "LG OLED CX Series TV" },
                    { 13, 5, "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.", "https://example.com/samsungqn900a.jpg", 2999.00m, "Samsung QN900A Series TV" },
                    { 14, 5, "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.", "https://example.com/sonya8h.jpg", 1499.00m, "Sony A8H Series TV" },
                    { 15, 5, "A high-performance laptop with a 14-inch display and long battery life.", "https://example.com/thinkpadx1carbon.jpg", 1499.00m, "Lenovo ThinkPad X1 Carbon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
