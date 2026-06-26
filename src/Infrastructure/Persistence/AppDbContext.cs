using Domain.Entities;
using Microsoft.EntityFrameworkCore;


using Application.Common.Interfaces;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Parish> Parishes => Set<Parish>();
    public DbSet<AcademicYear> AcademicYears => Set<AcademicYear>();
    public DbSet<Semester> Semesters => Set<Semester>();

    public DbSet<CatechismGrade> CatechismGrades => Set<CatechismGrade>();
    public DbSet<CatechismClass> CatechismClasses => Set<CatechismClass>();

    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Assistant> Assistants => Set<Assistant>();

    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentCard> StudentCards => Set<StudentCard>();
    public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();

    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AttendanceSession> AttendanceSessions => Set<AttendanceSession>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    public DbSet<QuestionCategory> QuestionCategories => Set<QuestionCategory>();
    public DbSet<Question> Questions => Set<Question>();

    public DbSet<ExamBlueprint> ExamBlueprints => Set<ExamBlueprint>();
    public DbSet<ExamBlueprintDetail> ExamBlueprintDetails => Set<ExamBlueprintDetail>();

    public DbSet<GeneratedExam> GeneratedExams => Set<GeneratedExam>();

    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamScore> ExamScores => Set<ExamScore>();

    public DbSet<Sacrament> Sacraments => Set<Sacrament>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}