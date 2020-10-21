using Microsoft.EntityFrameworkCore.Migrations;

namespace Ommi.Business.Migrations
{
    public partial class AddedBoardStateAndTracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoardStateId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoardStates",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 255, nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    TempoBPM = table.Column<int>(nullable: false),
                    NumberOfSteps = table.Column<int>(nullable: false),
                    RoomId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardStates_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 255, nullable: false),
                    Steps = table.Column<string>(maxLength: 64, nullable: false),
                    InstrumentName = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false),
                    BoardStateId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_BoardStates_BoardStateId",
                        column: x => x.BoardStateId,
                        principalTable: "BoardStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardStates_RoomId",
                table: "BoardStates",
                column: "RoomId",
                unique: true,
                filter: "[RoomId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_BoardStateId",
                table: "Tracks",
                column: "BoardStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "BoardStates");

            migrationBuilder.DropColumn(
                name: "BoardStateId",
                table: "Rooms");
        }
    }
}
