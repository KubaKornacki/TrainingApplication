using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class UpdateExcercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Machine",
                table: "Excercises",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Machine",
                table: "Excercises");
        }
    }
}
