using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tntt_api.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendances_attendance_sessions_AttendanceSessionId",
                table: "attendances");

            migrationBuilder.DropIndex(
                name: "IX_student_enrollments_StudentId_CatechismClassId_IsCurrent",
                table: "student_enrollments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_ClassId_SemesterId_TeacherId",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_SemesterId",
                table: "assignments");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "teachers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "teachers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "teachers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "students",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "students",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "students",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "students",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "students",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "student_cards",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "PrintCount",
                table: "student_cards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "student_cards",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "semesters",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "parishes",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "parishes",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "parishes",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "parishes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "catechism_grades",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "attendance_sessions",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CatechismClassId",
                table: "attendance_sessions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "assistants",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "assistants",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "assistants",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "assignments",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "academic_years",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "academic_years",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_FullName",
                table: "teachers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_IsDeleted",
                table: "teachers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_students_FullName",
                table: "students",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_students_IsDeleted",
                table: "students",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_student_enrollments_IsDeleted",
                table: "student_enrollments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_student_enrollments_StudentId_CatechismClassId_JoinDate",
                table: "student_enrollments",
                columns: new[] { "StudentId", "CatechismClassId", "JoinDate" });

            migrationBuilder.CreateIndex(
                name: "IX_student_cards_IsDeleted",
                table: "student_cards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_semesters_AcademicYearId",
                table: "semesters",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_semesters_IsCurrent",
                table: "semesters",
                column: "IsCurrent");

            migrationBuilder.CreateIndex(
                name: "IX_semesters_IsDeleted",
                table: "semesters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_questions_IsDeleted",
                table: "questions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_question_categories_IsDeleted",
                table: "question_categories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_parishes_Code",
                table: "parishes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generated_exams_IsDeleted",
                table: "generated_exams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_exams_IsDeleted",
                table: "exams",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_exam_scores_IsDeleted",
                table: "exam_scores",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_exam_blueprints_IsDeleted",
                table: "exam_blueprints",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_exam_blueprint_details_IsDeleted",
                table: "exam_blueprint_details",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_grades_DisplayOrder",
                table: "catechism_grades",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_grades_IsDeleted",
                table: "catechism_grades",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_grades_ParishId",
                table: "catechism_grades",
                column: "ParishId");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_classes_IsDeleted",
                table: "catechism_classes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_classes_ParishId",
                table: "catechism_classes",
                column: "ParishId");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_IsDeleted",
                table: "attendances",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_sessions_CatechismClassId",
                table: "attendance_sessions",
                column: "CatechismClassId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_sessions_IsDeleted",
                table: "attendance_sessions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_assistants_FullName",
                table: "assistants",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_assistants_IsDeleted",
                table: "assistants",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_ClassId",
                table: "assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_IsDeleted",
                table: "assignments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_SemesterId_ClassId_TeacherId",
                table: "assignments",
                columns: new[] { "SemesterId", "ClassId", "TeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_academic_years_IsCurrent",
                table: "academic_years",
                column: "IsCurrent");

            migrationBuilder.CreateIndex(
                name: "IX_academic_years_IsDeleted",
                table: "academic_years",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_academic_years_ParishId",
                table: "academic_years",
                column: "ParishId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_sessions_catechism_classes_CatechismClassId",
                table: "attendance_sessions",
                column: "CatechismClassId",
                principalTable: "catechism_classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_attendances_attendance_sessions_AttendanceSessionId",
                table: "attendances",
                column: "AttendanceSessionId",
                principalTable: "attendance_sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_sessions_catechism_classes_CatechismClassId",
                table: "attendance_sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_attendances_attendance_sessions_AttendanceSessionId",
                table: "attendances");

            migrationBuilder.DropIndex(
                name: "IX_teachers_FullName",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_IsDeleted",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_students_FullName",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_IsDeleted",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_student_enrollments_IsDeleted",
                table: "student_enrollments");

            migrationBuilder.DropIndex(
                name: "IX_student_enrollments_StudentId_CatechismClassId_JoinDate",
                table: "student_enrollments");

            migrationBuilder.DropIndex(
                name: "IX_student_cards_IsDeleted",
                table: "student_cards");

            migrationBuilder.DropIndex(
                name: "IX_semesters_AcademicYearId",
                table: "semesters");

            migrationBuilder.DropIndex(
                name: "IX_semesters_IsCurrent",
                table: "semesters");

            migrationBuilder.DropIndex(
                name: "IX_semesters_IsDeleted",
                table: "semesters");

            migrationBuilder.DropIndex(
                name: "IX_questions_IsDeleted",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_question_categories_IsDeleted",
                table: "question_categories");

            migrationBuilder.DropIndex(
                name: "IX_parishes_Code",
                table: "parishes");

            migrationBuilder.DropIndex(
                name: "IX_generated_exams_IsDeleted",
                table: "generated_exams");

            migrationBuilder.DropIndex(
                name: "IX_exams_IsDeleted",
                table: "exams");

            migrationBuilder.DropIndex(
                name: "IX_exam_scores_IsDeleted",
                table: "exam_scores");

            migrationBuilder.DropIndex(
                name: "IX_exam_blueprints_IsDeleted",
                table: "exam_blueprints");

            migrationBuilder.DropIndex(
                name: "IX_exam_blueprint_details_IsDeleted",
                table: "exam_blueprint_details");

            migrationBuilder.DropIndex(
                name: "IX_catechism_grades_DisplayOrder",
                table: "catechism_grades");

            migrationBuilder.DropIndex(
                name: "IX_catechism_grades_IsDeleted",
                table: "catechism_grades");

            migrationBuilder.DropIndex(
                name: "IX_catechism_grades_ParishId",
                table: "catechism_grades");

            migrationBuilder.DropIndex(
                name: "IX_catechism_classes_IsDeleted",
                table: "catechism_classes");

            migrationBuilder.DropIndex(
                name: "IX_catechism_classes_ParishId",
                table: "catechism_classes");

            migrationBuilder.DropIndex(
                name: "IX_attendances_IsDeleted",
                table: "attendances");

            migrationBuilder.DropIndex(
                name: "IX_attendance_sessions_CatechismClassId",
                table: "attendance_sessions");

            migrationBuilder.DropIndex(
                name: "IX_attendance_sessions_IsDeleted",
                table: "attendance_sessions");

            migrationBuilder.DropIndex(
                name: "IX_assistants_FullName",
                table: "assistants");

            migrationBuilder.DropIndex(
                name: "IX_assistants_IsDeleted",
                table: "assistants");

            migrationBuilder.DropIndex(
                name: "IX_assignments_ClassId",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_IsDeleted",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_SemesterId_ClassId_TeacherId",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_academic_years_IsCurrent",
                table: "academic_years");

            migrationBuilder.DropIndex(
                name: "IX_academic_years_IsDeleted",
                table: "academic_years");

            migrationBuilder.DropIndex(
                name: "IX_academic_years_ParishId",
                table: "academic_years");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "student_cards");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "parishes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "parishes");

            migrationBuilder.DropColumn(
                name: "CatechismClassId",
                table: "attendance_sessions");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "assignments");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "academic_years");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "teachers",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "teachers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "teachers",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "students",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "students",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "students",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "students",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "student_cards",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "PrintCount",
                table: "student_cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "semesters",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "parishes",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "parishes",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "catechism_grades",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "attendance_sessions",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "assistants",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "assistants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "assistants",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "academic_years",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_student_enrollments_StudentId_CatechismClassId_IsCurrent",
                table: "student_enrollments",
                columns: new[] { "StudentId", "CatechismClassId", "IsCurrent" });

            migrationBuilder.CreateIndex(
                name: "IX_assignments_ClassId_SemesterId_TeacherId",
                table: "assignments",
                columns: new[] { "ClassId", "SemesterId", "TeacherId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignments_SemesterId",
                table: "assignments",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendances_attendance_sessions_AttendanceSessionId",
                table: "attendances",
                column: "AttendanceSessionId",
                principalTable: "attendance_sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
