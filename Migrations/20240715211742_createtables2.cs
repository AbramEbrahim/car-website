using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace car_web.Migrations
{
    /// <inheritdoc />
    public partial class createtables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Combanies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HONDA" },
                    { 2, "HYUNDAI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Combanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Combanies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
