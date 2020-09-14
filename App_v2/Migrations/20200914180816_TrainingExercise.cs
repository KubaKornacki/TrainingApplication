using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class TrainingExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingExercises",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainingID = table.Column<int>(nullable: true),
                    ExcerciseID = table.Column<int>(nullable: true),
                    Set = table.Column<int>(nullable: false),
                    Repeat = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingExercises_Excercises_ExcerciseID",
                        column: x => x.ExcerciseID,
                        principalTable: "Excercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingExercises_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_ExcerciseID",
                table: "TrainingExercises",
                column: "ExcerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_TrainingID",
                table: "TrainingExercises",
                column: "TrainingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExercises");
        }
    }
}
