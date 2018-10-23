using Microsoft.EntityFrameworkCore.Migrations;

namespace Dissent.Migrations
{
    public partial class migge3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Text",
                table: "Text");

            migrationBuilder.RenameTable(
                name: "Text",
                newName: "Tweets");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Tweets",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "language",
                table: "Tweets",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tweets",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets");

            migrationBuilder.RenameTable(
                name: "Tweets",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Text",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Text",
                newName: "language");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Text",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Text",
                table: "Text",
                column: "id");
        }
    }
}
