using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class PeopleExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleExercises",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppUserId = table.Column<string>(nullable: true),
                    ExcerciseID = table.Column<int>(nullable: true),
                    Max = table.Column<double>(nullable: false),
                    Progress = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleExercises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PeopleExercises_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeopleExercises_Excercises_ExcerciseID",
                        column: x => x.ExcerciseID,
                        principalTable: "Excercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleExercises_AppUserId",
                table: "PeopleExercises",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleExercises_ExcerciseID",
                table: "PeopleExercises",
                column: "ExcerciseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleExercises");
        }
    }
}
