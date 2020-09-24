using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App_v2.Migrations
{
    public partial class Subtraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingID",
                table: "TrainingExercises");

            migrationBuilder.RenameColumn(
                name: "TrainingID",
                table: "TrainingExercises",
                newName: "SubtrainingID");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercises_TrainingID",
                table: "TrainingExercises",
                newName: "IX_TrainingExercises_SubtrainingID");

            migrationBuilder.CreateTable(
                name: "Subtrainings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TrainingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtrainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subtrainings_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subtrainings_TrainingID",
                table: "Subtrainings",
                column: "TrainingID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Subtrainings_SubtrainingID",
                table: "TrainingExercises",
                column: "SubtrainingID",
                principalTable: "Subtrainings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Subtrainings_SubtrainingID",
                table: "TrainingExercises");

            migrationBuilder.DropTable(
                name: "Subtrainings");

            migrationBuilder.RenameColumn(
                name: "SubtrainingID",
                table: "TrainingExercises",
                newName: "TrainingID");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercises_SubtrainingID",
                table: "TrainingExercises",
                newName: "IX_TrainingExercises_TrainingID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingID",
                table: "TrainingExercises",
                column: "TrainingID",
                principalTable: "Trainings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
