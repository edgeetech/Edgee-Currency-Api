using Microsoft.EntityFrameworkCore.Migrations;

namespace Edgee.Api.Dictionary.Migrations
{
    public partial class EdgeeApiDictionaryModelDataLayerNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DictionaryItems_LanguageId",
                table: "DictionaryItems",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryItems_Languages_LanguageId",
                table: "DictionaryItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryItems_Languages_LanguageId",
                table: "DictionaryItems");

            migrationBuilder.DropIndex(
                name: "IX_DictionaryItems_LanguageId",
                table: "DictionaryItems");
        }
    }
}
