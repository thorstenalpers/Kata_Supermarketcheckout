using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupermarketCheckout.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleDiscounts",
                columns: table => new
                {
                    ArticleDiscountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    NumberOfArticles = table.Column<int>(nullable: false),
                    NewPrice = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDiscounts", x => x.ArticleDiscountID);
                    table.ForeignKey(
                        name: "FK_ArticleDiscounts_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticlePrices",
                columns: table => new
                {
                    ArticlePriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePrices", x => x.ArticlePriceID);
                    table.ForeignKey(
                        name: "FK_ArticlePrices_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDiscounts_ArticleId",
                table: "ArticleDiscounts",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePrices_ArticleId",
                table: "ArticlePrices",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Name",
                table: "Articles",
                column: "Name",
                unique: true);
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
