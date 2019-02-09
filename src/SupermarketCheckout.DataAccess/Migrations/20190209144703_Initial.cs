using Microsoft.EntityFrameworkCore.Migrations;

namespace SupermarketCheckout.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(nullable: false),
                    NumberOfArticles = table.Column<int>(nullable: false),
                    NewPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleDiscounts_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticlePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlePrices_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Apple" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Banana" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Peach" });

            migrationBuilder.InsertData(
                table: "ArticleDiscounts",
                columns: new[] { "Id", "ArticleId", "NewPrice", "NumberOfArticles" },
                values: new object[] { 2, 1, 45m, 2 });

            migrationBuilder.InsertData(
                table: "ArticleDiscounts",
                columns: new[] { "Id", "ArticleId", "NewPrice", "NumberOfArticles" },
                values: new object[] { 1, 2, 130m, 3 });

            migrationBuilder.InsertData(
                table: "ArticlePrices",
                columns: new[] { "Id", "ArticleId", "UnitPrice" },
                values: new object[] { 2, 1, 30m });

            migrationBuilder.InsertData(
                table: "ArticlePrices",
                columns: new[] { "Id", "ArticleId", "UnitPrice" },
                values: new object[] { 1, 2, 50m });

            migrationBuilder.InsertData(
                table: "ArticlePrices",
                columns: new[] { "Id", "ArticleId", "UnitPrice" },
                values: new object[] { 3, 3, 60m });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDiscounts_ArticleId",
                table: "ArticleDiscounts",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePrices_ArticleId",
                table: "ArticlePrices",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleDiscounts");

            migrationBuilder.DropTable(
                name: "ArticlePrices");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
