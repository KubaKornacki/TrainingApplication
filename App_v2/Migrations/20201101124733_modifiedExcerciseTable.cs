using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class modifiedExcerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dynamic",
                table: "Excercises",
                newName: "Isolated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isolated",
                table: "Excercises",
                newName: "Dynamic");
        }
    }
}
