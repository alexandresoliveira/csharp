using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningPokerApi.Migrations
{
    public partial class ChangeDefaultValueOnTimestampAndRequiredFieldOnUserHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_votes_cards_cardId",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_history_usersHistoryId",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_userId",
                table: "votes");

            migrationBuilder.RenameColumn(
                name: "usersHistoryId",
                table: "votes",
                newName: "UsersHistoryId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "votes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "cardId",
                table: "votes",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_usersHistoryId",
                table: "votes",
                newName: "IX_votes_UsersHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_userId",
                table: "votes",
                newName: "IX_votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_cardId",
                table: "votes",
                newName: "IX_votes_CardId");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "users_history",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_cards_CardId",
                table: "votes",
                column: "CardId",
                principalTable: "cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_history_UsersHistoryId",
                table: "votes",
                column: "UsersHistoryId",
                principalTable: "users_history",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_votes_cards_CardId",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_history_UsersHistoryId",
                table: "votes");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes");

            migrationBuilder.RenameColumn(
                name: "UsersHistoryId",
                table: "votes",
                newName: "usersHistoryId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "votes",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "votes",
                newName: "cardId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_UsersHistoryId",
                table: "votes",
                newName: "IX_votes_usersHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_UserId",
                table: "votes",
                newName: "IX_votes_userId");

            migrationBuilder.RenameIndex(
                name: "IX_votes_CardId",
                table: "votes",
                newName: "IX_votes_cardId");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "users_history",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_cards_cardId",
                table: "votes",
                column: "cardId",
                principalTable: "cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_history_usersHistoryId",
                table: "votes",
                column: "usersHistoryId",
                principalTable: "users_history",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_userId",
                table: "votes",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
