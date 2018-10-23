using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dissent.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SearchQueryId",
                table: "TweetsWithSentiment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchQuery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TweetsWithSentiment_SearchQueryId",
                table: "TweetsWithSentiment",
                column: "SearchQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetsWithSentiment_Query_SearchQueryId",
                table: "TweetsWithSentiment",
                column: "SearchQueryId",
                principalTable: "Query",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetsWithSentiment_Query_SearchQueryId",
                table: "TweetsWithSentiment");

            migrationBuilder.DropTable(
                name: "Query");

            migrationBuilder.DropIndex(
                name: "IX_TweetsWithSentiment_SearchQueryId",
                table: "TweetsWithSentiment");

            migrationBuilder.DropColumn(
                name: "SearchQueryId",
                table: "TweetsWithSentiment");
        }
    }
}
