using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tntt_api.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentEnrollmentAndStudentCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student_cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IssuedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PrintCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_cards_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CatechismClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeaveDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_enrollments_catechism_classes_CatechismClassId",
                        column: x => x.CatechismClassId,
                        principalTable: "catechism_classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_enrollments_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_cards_StudentId",
                table: "student_cards",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_student_cards_Token",
                table: "student_cards",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_enrollments_CatechismClassId",
                table: "student_enrollments",
                column: "CatechismClassId");

            migrationBuilder.CreateIndex(
                name: "IX_student_enrollments_StudentId_CatechismClassId_IsCurrent",
                table: "student_enrollments",
                columns: new[] { "StudentId", "CatechismClassId", "IsCurrent" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_cards");

            migrationBuilder.DropTable(
                name: "student_enrollments");
        }
    }
}
