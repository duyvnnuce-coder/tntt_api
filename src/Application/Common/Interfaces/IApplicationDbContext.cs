using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Parish> Parishes { get; }
    DbSet<AcademicYear> AcademicYears { get; }
    DbSet<Semester> Semesters { get; }
    DbSet<CatechismGrade> CatechismGrades { get; }
    DbSet<CatechismClass> CatechismClasses { get; }

    DbSet<Teacher> Teachers { get; }
    DbSet<Assistant> Assistants { get; }

    DbSet<Student> Students { get; }
    DbSet<StudentCard> StudentCards { get; }
    DbSet<StudentEnrollment> StudentEnrollments { get; }

    DbSet<Assignment> Assignments { get; }
    DbSet<AttendanceSession> AttendanceSessions { get; }
    DbSet<Attendance> Attendances { get; }

    DbSet<QuestionCategory> QuestionCategories { get; }
    DbSet<Question> Questions { get; }

    DbSet<ExamBlueprint> ExamBlueprints { get; }
    DbSet<ExamBlueprintDetail> ExamBlueprintDetails { get; }

    DbSet<GeneratedExam> GeneratedExams { get; }

    DbSet<Exam> Exams { get; }
    DbSet<ExamScore> ExamScores { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}