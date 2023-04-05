using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Csharp_Coal.Migrations
{
    /// <inheritdoc />
    public partial class newCoalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SizeCoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Carbon = table.Column<int>(type: "integer", nullable: false),
                    Volatiles = table.Column<int>(type: "integer", nullable: false),
                    Heat = table.Column<string>(type: "text", nullable: false),
                    SizeCoalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_SizeCoals_SizeCoalId",
                        column: x => x.SizeCoalId,
                        principalTable: "SizeCoals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategorySizes",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    SizeCoalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySizes", x => new { x.CategoryId, x.SizeCoalId });
                    table.ForeignKey(
                        name: "FK_CategorySizes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySizes_SizeCoals_SizeCoalId",
                        column: x => x.SizeCoalId,
                        principalTable: "SizeCoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SizeCoalId",
                table: "Categories",
                column: "SizeCoalId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySizes_SizeCoalId",
                table: "CategorySizes",
                column: "SizeCoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySizes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SizeCoals");
        }
    }
}
