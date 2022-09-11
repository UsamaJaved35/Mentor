using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentor.Migrations
{
    public partial class idNameChanging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tutors",
                newName: "TId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "SId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TId",
                table: "Tutors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SId",
                table: "Students",
                newName: "Id");
        }
    }
}
