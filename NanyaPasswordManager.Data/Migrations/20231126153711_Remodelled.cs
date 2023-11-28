using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NanyaPasswordManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remodelled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPasswords_AspNetUsers_UserId",
                table: "UserPasswords");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPasswords",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords",
                newName: "IX_UserPasswords_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPasswords_AspNetUsers_ApplicationUserId",
                table: "UserPasswords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPasswords_AspNetUsers_ApplicationUserId",
                table: "UserPasswords");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UserPasswords",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPasswords_ApplicationUserId",
                table: "UserPasswords",
                newName: "IX_UserPasswords_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPasswords_AspNetUsers_UserId",
                table: "UserPasswords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
