using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tntt_api.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_CatechismClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catechism_classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParishId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcademicYearId = table.Column<Guid>(type: "uuid", nullable: false),
                    CatechismGradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    MaxStudents = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catechism_classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catechism_classes_academic_years_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "academic_years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_catechism_classes_catechism_grades_CatechismGradeId",
                        column: x => x.CatechismGradeId,
                        principalTable: "catechism_grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_catechism_classes_parishes_ParishId",
                        column: x => x.ParishId,
                        principalTable: "parishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_catechism_classes_AcademicYearId",
                table: "catechism_classes",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_classes_CatechismGradeId",
                table: "catechism_classes",
                column: "CatechismGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_catechism_classes_ParishId_AcademicYearId_Code",
                table: "catechism_classes",
                columns: new[] { "ParishId", "AcademicYearId", "Code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catechism_classes");
        }
    }
}
