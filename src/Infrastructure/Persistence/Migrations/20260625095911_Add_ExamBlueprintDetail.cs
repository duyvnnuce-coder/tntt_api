using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tntt_api.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_ExamBlueprintDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exam_blueprint_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamBlueprintId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    EasyQuestions = table.Column<int>(type: "integer", nullable: false),
                    MediumQuestions = table.Column<int>(type: "integer", nullable: false),
                    HardQuestions = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_blueprint_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exam_blueprint_details_exam_blueprints_ExamBlueprintId",
                        column: x => x.ExamBlueprintId,
                        principalTable: "exam_blueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exam_blueprint_details_question_categories_QuestionCategory~",
                        column: x => x.QuestionCategoryId,
                        principalTable: "question_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exam_blueprint_details_ExamBlueprintId_QuestionCategoryId",
                table: "exam_blueprint_details",
                columns: new[] { "ExamBlueprintId", "QuestionCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exam_blueprint_details_QuestionCategoryId",
                table: "exam_blueprint_details",
                column: "QuestionCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_blueprint_details");
        }
    }
}
