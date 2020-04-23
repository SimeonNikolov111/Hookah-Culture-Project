using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahCulture.Data.Migrations
{
    public partial class ChangingChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedOn",
                table: "ChatMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ChatMessages");
        }
    }
}
