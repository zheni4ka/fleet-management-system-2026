using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "DestinationLocationId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartLocationId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country" },
                values: new object[,]
                {
                    { 1, "Kyiv", "Ukraine" },
                    { 2, "Lviv", "Ukraine" },
                    { 3, "Odessa", "Ukraine" },
                    { 4, "Kharkiv", "Ukraine" },
                    { 5, "Dnipro", "Ukraine" },
                    { 6, "Zaporizhzhia", "Ukraine" },
                    { 7, "Ivano-Frankivsk", "Ukraine" },
                    { 8, "Ternopil", "Ukraine" },
                    { 9, "Chernivtsi", "Ukraine" },
                    { 10, "Vinnytsia", "Ukraine" },
                    { 11, "Rivne", "Ukraine" },
                    { 12, "Lutsk", "Ukraine" },
                    { 13, "Poltava", "Ukraine" },
                    { 14, "Chernihiv", "Ukraine" },
                    { 15, "Cherkasy", "Ukraine" },
                    { 16, "Khmelnytskyi", "Ukraine" },
                    { 17, "Zhytomyr", "Ukraine" },
                    { 18, "Uzhhorod", "Ukraine" },
                    { 19, "Mykolaiv", "Ukraine" },
                    { 20, "Kherson", "Ukraine" },
                    { 21, "Sumy", "Ukraine" },
                    { 22, "Kropyvnytskyi", "Ukraine" },
                    { 24, "Warsaw", "Poland" },
                    { 25, "Krakow", "Poland" },
                    { 26, "Wroclaw", "Poland" },
                    { 27, "Gdansk", "Poland" },
                    { 28, "Poznan", "Poland" },
                    { 29, "Lodz", "Poland" },
                    { 30, "Katowice", "Poland" },
                    { 31, "Lublin", "Poland" },
                    { 32, "Rzeszow", "Poland" },
                    { 33, "Szczecin", "Poland" },
                    { 34, "Bydgoszcz", "Poland" },
                    { 35, "Gdynia", "Poland" },
                    { 36, "Bialystok", "Poland" },
                    { 37, "Czestochowa", "Poland" },
                    { 38, "Radom", "Poland" },
                    { 39, "Torun", "Poland" },
                    { 40, "Kielce", "Poland" },
                    { 41, "Gliwice", "Poland" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinationLocationId",
                table: "Routes",
                column: "DestinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartLocationId",
                table: "Routes",
                column: "StartLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_DestinationLocationId",
                table: "Routes",
                column: "DestinationLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_StartLocationId",
                table: "Routes",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_DestinationLocationId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_StartLocationId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DestinationLocationId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_StartLocationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DestinationLocationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLocationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Routes");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
