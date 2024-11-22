using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceConnect.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProfileStatuscolumninUserandInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileStatus",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileStatus",
                table: "Instructors");
        }
    }
}
