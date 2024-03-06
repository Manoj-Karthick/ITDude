using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITDude.API.Migrations
{
    /// <inheritdoc />
    public partial class Changedtablenametomatchpattern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Repeat_RepeatId",
                table: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repeat",
                table: "Repeat");

            migrationBuilder.RenameTable(
                name: "Repeat",
                newName: "Repeats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repeats",
                table: "Repeats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Repeats_RepeatId",
                table: "Habits",
                column: "RepeatId",
                principalTable: "Repeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Repeats_RepeatId",
                table: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repeats",
                table: "Repeats");

            migrationBuilder.RenameTable(
                name: "Repeats",
                newName: "Repeat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repeat",
                table: "Repeat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Repeat_RepeatId",
                table: "Habits",
                column: "RepeatId",
                principalTable: "Repeat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
