using Application.Common.Interfaces;
using Application.Features.AcademicYears.CreateAcademicYear;
using Application.Features.Assignments.CreateAssignment;
using Application.Features.Assistants.CreateAssistant;
using Application.Features.Attendances.CreateAttendance;
using Application.Features.AttendanceSessions.CreateAttendanceSession;
using Application.Features.CatechismClasses.CreateCatechismClass;
using Application.Features.CatechismGrades.CreateCatechismGrade;
using Application.Features.Parishes.CreateParish;
using Application.Features.Sacraments.CreateSacrament;
using Application.Features.Sacraments.GetSacramentById;
using Application.Features.Sacraments.GetSacramentList;
using Application.Features.Semesters.CreateSemester;
using Application.Features.Students.CreateStudent;
using Application.Features.Students.GetStudentById;
using Application.Features.Teachers.CreateTeacher;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<AppDbContext>());

        services.AddRepositories();

        services.AddServices();

        services.AddHandlers();

        return services;
    }
}