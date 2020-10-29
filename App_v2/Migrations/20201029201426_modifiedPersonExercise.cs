using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class modifiedPersonExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LastTrainingMax",
                table: "PeopleExercises",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTrainingMax",
                table: "PeopleExercises");
        }
    }
}
