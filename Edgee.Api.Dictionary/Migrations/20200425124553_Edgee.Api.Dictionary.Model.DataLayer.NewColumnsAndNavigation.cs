using Microsoft.EntityFrameworkCore.Migrations;

namespace Edgee.Api.Dictionary.Migrations
{
    public partial class EdgeeApiDictionaryModelDataLayerNewColumnsAndNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Languages",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NativeName",
                table: "Languages",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "NativeName",
                table: "Languages");
        }
    }
}
