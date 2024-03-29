using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HokmChampions.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seri = table.Column<int>(type: "int", nullable: false),
                    round = table.Column<int>(type: "int", nullable: false),
                    matchNo = table.Column<int>(type: "int", nullable: false),
                    player1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    player2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    player1_score = table.Column<int>(type: "int", nullable: false),
                    player2_score = table.Column<int>(type: "int", nullable: false),
                    player1_top_score = table.Column<int>(type: "int", nullable: false),
                    player2_top_score = table.Column<int>(type: "int", nullable: false),
                    winner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchIdFK = table.Column<long>(type: "bigint", nullable: false),
                    MatcheIdFK = table.Column<long>(type: "bigint", nullable: false),
                    playerNo = table.Column<int>(type: "int", nullable: false),
                    cardType = table.Column<int>(type: "int", nullable: false),
                    cardNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Matches_MatchIdFK",
                        column: x => x.MatchIdFK,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_MatchIdFK",
                table: "Cards",
                column: "MatchIdFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
