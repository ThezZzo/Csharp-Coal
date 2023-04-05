using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Csharp_Coal.Migrations
{
    /// <inheritdoc />
    public partial class hasDataCoalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Carbon", "Heat", "Name", "SizeCoalId", "Volatiles" },
                values: new object[,]
                {
                    { 1, 70, "6500-7500", "Длиннопламенный", null, 50 },
                    { 2, 65, "4500-5500", "Бурый", null, 45 }
                });

            migrationBuilder.InsertData(
                table: "SizeCoals",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "Крупный", "более 100мм" },
                    { 2, "Рядовой", "не имеет ограничений" }
                });

            migrationBuilder.InsertData(
                table: "CategorySizes",
                columns: new[] { "CategoryId", "SizeCoalId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumns: new[] { "CategoryId", "SizeCoalId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumns: new[] { "CategoryId", "SizeCoalId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumns: new[] { "CategoryId", "SizeCoalId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategorySizes",
                keyColumns: new[] { "CategoryId", "SizeCoalId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SizeCoals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SizeCoals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
