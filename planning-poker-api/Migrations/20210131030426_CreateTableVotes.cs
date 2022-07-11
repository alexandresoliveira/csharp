using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningPokerApi.Migrations
{
    public partial class CreateTableVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "votes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: true),
                    cardId = table.Column<Guid>(type: "uuid", nullable: true),
                    usersHistoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.id);
                    table.ForeignKey(
                        name: "FK_votes_cards_cardId",
                        column: x => x.cardId,
                        principalTable: "cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_votes_users_history_usersHistoryId",
                        column: x => x.usersHistoryId,
                        principalTable: "users_history",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_votes_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_votes_cardId",
                table: "votes",
                column: "cardId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_userId",
                table: "votes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_usersHistoryId",
                table: "votes",
                column: "usersHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "votes");
        }
    }
}
