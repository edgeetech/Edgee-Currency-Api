using Microsoft.EntityFrameworkCore.Migrations;

namespace Edgee.Api.VutbuCore.Migrations
{
    public partial class EdgeeApiUserFinancial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFinancials",
                columns: table => new
                {
                    UserFinancialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    IBAN = table.Column<string>(maxLength: 250, nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: true),
                    SortCode = table.Column<string>(maxLength: 20, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFinancials", x => x.UserFinancialId);
                    table.ForeignKey(
                        name: "FK_UserFinancials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFinancials_UserId",
                table: "UserFinancials",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFinancials");
        }
    }
}
