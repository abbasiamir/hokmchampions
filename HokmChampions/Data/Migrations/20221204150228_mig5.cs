using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HokmChampions.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatcheIdFK",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MatcheIdFK",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
