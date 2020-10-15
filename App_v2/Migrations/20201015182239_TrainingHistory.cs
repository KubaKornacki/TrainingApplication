using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class TrainingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryTrainings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDatetime = table.Column<DateTime>(nullable: false),
                    SetN = table.Column<int>(nullable: false),
                    Repeats = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    TrainingExerciseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTrainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HistoryTrainings_TrainingExercises_TrainingExerciseID",
                        column: x => x.TrainingExerciseID,
                        principalTable: "TrainingExercises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTrainings_TrainingExerciseID",
                table: "HistoryTrainings",
                column: "TrainingExerciseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryTrainings");
        }
    }
}
