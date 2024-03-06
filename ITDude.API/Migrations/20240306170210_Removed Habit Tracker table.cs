using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITDude.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedHabitTrackertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitTrackers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HabitTrackers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HabitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitTrackers_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitTrackers_HabitId",
                table: "HabitTrackers",
                column: "HabitId");
        }
    }
}
