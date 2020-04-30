using Microsoft.EntityFrameworkCore.Migrations;

namespace Edgee.Api.VutbuCore.Migrations
{
    public partial class GroupAdminDbSetCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmin_Groups_GroupId",
                table: "GroupAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmin_Users_UserId",
                table: "GroupAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAdmin",
                table: "GroupAdmin");

            migrationBuilder.RenameTable(
                name: "GroupAdmin",
                newName: "GroupAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmin_UserId",
                table: "GroupAdmins",
                newName: "IX_GroupAdmins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmin_GroupId",
                table: "GroupAdmins",
                newName: "IX_GroupAdmins_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins",
                column: "GroupAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_Groups_GroupId",
                table: "GroupAdmins",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmins_Users_UserId",
                table: "GroupAdmins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_Groups_GroupId",
                table: "GroupAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAdmins_Users_UserId",
                table: "GroupAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupAdmins",
                table: "GroupAdmins");

            migrationBuilder.RenameTable(
                name: "GroupAdmins",
                newName: "GroupAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmins_UserId",
                table: "GroupAdmin",
                newName: "IX_GroupAdmin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAdmins_GroupId",
                table: "GroupAdmin",
                newName: "IX_GroupAdmin_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupAdmin",
                table: "GroupAdmin",
                column: "GroupAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmin_Groups_GroupId",
                table: "GroupAdmin",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAdmin_Users_UserId",
                table: "GroupAdmin",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
