using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahCulture.Data.Migrations
{
    public partial class ChangingChatModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatMessages");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ChatMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "ChatMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "ChatMessages");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ChatMessages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
