using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HokmChampions.Data.Migrations
{
    public partial class remig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Matches_MatchIdFK",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_MatchIdFK",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "MatchIdFK",
                table: "Cards",
                newName: "MatcheIdFK");

            migrationBuilder.AddColumn<long>(
                name: "MatchId",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_MatchId",
                table: "Cards",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Matches_MatchId",
                table: "Cards",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Matches_MatchId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_MatchId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "MatcheIdFK",
                table: "Cards",
                newName: "MatchIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_MatchIdFK",
                table: "Cards",
                column: "MatchIdFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Matches_MatchIdFK",
                table: "Cards",
                column: "MatchIdFK",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
