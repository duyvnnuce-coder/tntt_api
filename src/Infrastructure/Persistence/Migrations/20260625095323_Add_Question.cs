using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tntt_api.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CatechismGradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    AnswerA = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AnswerB = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AnswerC = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AnswerD = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CorrectAnswer = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    DifficultyLevel = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_catechism_grades_CatechismGradeId",
                        column: x => x.CatechismGradeId,
                        principalTable: "catechism_grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_questions_question_categories_QuestionCategoryId",
                        column: x => x.QuestionCategoryId,
                        principalTable: "question_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_CatechismGradeId",
                table: "questions",
                column: "CatechismGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_QuestionCategoryId_CatechismGradeId",
                table: "questions",
                columns: new[] { "QuestionCategoryId", "CatechismGradeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
