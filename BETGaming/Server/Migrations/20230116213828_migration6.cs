using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BETGaming.Server.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Sandbox", "https://play-lh.googleusercontent.com/QS31MR9QEDSRV4V8qro8YtwT72OvUJJPpWrgyqDLwNgLcEGDe2D7EJnakRJRIhYWUw" },
                    { 2, "Shooters (FPS and TPS)", "https://www.denofgeek.com/wp-content/uploads/2021/07/Far-Cry-2.jpg" },
                    { 3, "Multiplayer online battle arena (MOBA)", "https://i.ytimg.com/vi/lD-nWRWo7NU/maxresdefault.jpg" },
                    { 4, "Role-playing (RPG, ARPG, and More)", "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png" },
                    { 5, "Electronics", "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Usb" },
                    { 2, "CD" },
                    { 3, "Download" },
                    { 4, "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The first game", "images/3.png", "Game 1" },
                    { 2, 2, "The second game", "images/4.png", "Game 2" },
                    { 3, 3, "the third game", "images/3.png", "Game 3" },
                    { 4, 4, "The fourth game", "images/4.png", "Game 4" },
                    { 5, 5, "The latest iPhone with a 6.1-inch Super Retina XDR display.", "https://example.com/iphone12.jpg", "Apple iPhone 12" },
                    { 6, 5, "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.", "https://example.com/samsungs21.jpg", "Samsung Galaxy S21" },
                    { 7, 5, "A budget-friendly phone from Google with a 5.8-inch OLED display.", "https://example.com/pixel4a.jpg", "Google Pixel 4a" },
                    { 8, 5, "A high-performance phone with a 6.55-inch Fluid AMOLED display.", "https://example.com/oneplus8t.jpg", "OnePlus 8T" },
                    { 9, 5, "The latest gaming console from Sony with 8K graphics and ray tracing.", "https://example.com/ps5.jpg", "Sony PlayStation 5" },
                    { 10, 5, "The latest gaming console from Microsoft with 4K graphics and 120fps.", "https://example.com/xboxseriesx.jpg", "Microsoft Xbox Series X" },
                    { 11, 5, "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.", "https://example.com/switch.jpg", "Nintendo Switch" },
                    { 12, 5, "A 4K OLED TV with AI ThinQ and Google Assistant built-in.", "https://example.com/lgoledcx.jpg", "LG OLED CX Series TV" },
                    { 13, 5, "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.", "https://example.com/samsungqn900a.jpg", "Samsung QN900A Series TV" },
                    { 14, 5, "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.", "https://example.com/sonya8h.jpg", "Sony A8H Series TV" },
                    { 16, 1, "The highly-anticipated sequel to the critically-acclaimed game.", "", "The Last of Us Part II" },
                    { 17, 1, "An open-world RPG set in a futuristic metropolis.", "", "Cyberpunk 2077" },
                    { 18, 1, "An action RPG set in a post-apocalyptic world ruled by robotic creatures.", "", "Horizon Zero Dawn" },
                    { 19, 1, "An epic tale of life in America's unforgiving heartland.", "", "Red Dead Redemption 2" },
                    { 20, 1, "An open-world action RPG based on the bestselling fantasy series.", "", "The Witcher 3: Wild Hunt" },
                    { 21, 1, "An action game developed by Hideo Kojima, creator of the Metal Gear series.", "", "Death Stranding" },
                    { 22, 1, "An open-air adventure game set in a vast wilderness.", "", "The Legend of Zelda: Breath of the Wild" },
                    { 23, 1, "A 3D platformer featuring Mario's first sandbox-style gameplay.", "", "Super Mario Odyssey" },
                    { 24, 1, "A role-playing game that follows a group of high school students.", "", "Persona 5" },
                    { 25, 1, "A modern retelling of the classic RPG.", "", "Final Fantasy VII Remake" },
                    { 26, 1, "A game where players take on the role of a hunter and slay different monsters", "", "Monster Hunter: World" },
                    { 27, 1, "A team-based first-person shooter game developed by Blizzard Entertainment.", "", "Overwatch" },
                    { 28, 1, "A sandbox game where players can build and explore virtual worlds.", "", "Minecraft" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
