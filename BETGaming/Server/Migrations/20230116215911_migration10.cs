using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BETGaming.Server.Migrations
{
    /// <inheritdoc />
    public partial class migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "Sandbox");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Shooters", "Shooters" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Multiplayer", "Multiplayer" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Role-playing", "Role-playing" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "Electronics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://play-lh.googleusercontent.com/QS31MR9QEDSRV4V8qro8YtwT72OvUJJPpWrgyqDLwNgLcEGDe2D7EJnakRJRIhYWUw");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Shooters (FPS and TPS)", "https://www.denofgeek.com/wp-content/uploads/2021/07/Far-Cry-2.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Multiplayer online battle arena (MOBA)", "https://i.ytimg.com/vi/lD-nWRWo7NU/maxresdefault.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Url" },
                values: new object[] { "Role-playing (RPG, ARPG, and More)", "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png");
        }
    }
}
