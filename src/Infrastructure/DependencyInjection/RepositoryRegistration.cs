using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
       services.AddScoped<IExamScoreRepository, ExamScoreRepository>();
       services.AddScoped<IGeneratedExamRepository, GeneratedExamRepository>();
       services.AddScoped<IParishRepository, ParishRepository>();
       services.AddScoped<ICatechismClassRepository, CatechismClassRepository>();
       services.AddScoped<IExamBlueprintRepository, ExamBlueprintRepository>();
       services.AddScoped<IStudentRepository, StudentRepository>();
       services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
       services.AddScoped<IStudentCardRepository, StudentCardRepository>();
       services.AddScoped<ICatechismGradeRepository, CatechismGradeRepository>();
       services.AddScoped<ITeacherRepository, TeacherRepository>();
       services.AddScoped<IAssistantRepository, AssistantRepository>();
       services.AddScoped<ISacramentRepository, SacramentRepository>();
       services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
       services.AddScoped<IQuestionRepository, QuestionRepository>();
       services.AddScoped<IExamBlueprintDetailRepository, ExamBlueprintDetailRepository>();
       services.AddScoped<IExamRepository, ExamRepository>();

       services.AddScoped<IGeneratedExamRepository, GeneratedExamRepository>();
       services.AddScoped<IAssignmentRepository, AssignmentRepository>();
       services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
       services.AddScoped<IAttendanceSessionRepository, AttendanceSessionRepository>();
       services.AddScoped<ISemesterRepository, SemesterRepository>();
       services.AddScoped<IAttendanceRepository, AttendanceRepository>();




        return services;

    }
}