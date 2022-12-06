using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpboolflix.Migrations
{
    /// <inheritdoc />
    public partial class AddsCategoryContentMMRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryContent",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ContentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryContent", x => new { x.CategoriesId, x.ContentsId });
                    table.ForeignKey(
                        name: "FK_CategoryContent_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryContent_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryContent_ContentsId",
                table: "CategoryContent",
                column: "ContentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryContent");
        }
    }
}
