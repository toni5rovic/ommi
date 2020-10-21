using Microsoft.EntityFrameworkCore.Migrations;

namespace Ommi.Business.Migrations
{
    public partial class AddedSoundNameToTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoundName",
                table: "Tracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoundName",
                table: "Tracks");
        }
    }
}
