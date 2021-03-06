using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanningPokerApi.Migrations
{
    public partial class AddCreatedAtAndUpdatedAtColumnsOnTableVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "votes",
                type: "timestamp without time zone",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "votes",
                type: "timestamp without time zone",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "votes");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "votes");
        }
    }
}
