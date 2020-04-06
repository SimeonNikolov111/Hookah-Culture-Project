using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahCulture.Data.Migrations
{
    public partial class ChangineVoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Votes");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpVote",
                table: "Votes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpVote",
                table: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
