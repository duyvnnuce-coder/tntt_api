using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

using Application.Common.Interfaces;
using Infrastructure.Services;

using Domain.Interfaces;
using Infrastructure.Repositories;

using Application.Features.Sacraments.CreateSacrament;
using Application.Features.Students.CreateStudent;
using Application.Features.Teachers.CreateTeacher;
using Application.Features.Assistants.CreateAssistant;
using Application.Features.Parishes.CreateParish;
using Application.Features.CatechismClasses.CreateCatechismClass;
using Application.Features.AcademicYears.CreateAcademicYear;
using Application.Features.Semesters.CreateSemester;
using Application.Features.Assignments.CreateAssignment;
using Application.Features.AttendanceSessions.CreateAttendanceSession;
using Application.Features.CatechismGrades.CreateCatechismGrade;
using Application.Features.Attendances.CreateAttendance;
using Application.Features.Sacraments.GetSacramentById;



var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddScoped<IApplicationDbContext>(sp =>
    sp.GetRequiredService<AppDbContext>());


// Repository
builder.Services.AddScoped<IParishRepository, ParishRepository>();
builder.Services.AddScoped<ICatechismClassRepository, CatechismClassRepository>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
builder.Services.AddScoped<IStudentCardRepository, StudentCardRepository>();
builder.Services.AddScoped<ICatechismGradeRepository, CatechismGradeRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAssistantRepository, AssistantRepository>();
builder.Services.AddScoped<ISacramentRepository, SacramentRepository>();


// Services
builder.Services.AddScoped<ICodeGenerator, CodeGenerator>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
builder.Services.AddScoped<CreateAssignmentHandler>();
builder.Services.AddScoped<IAttendanceSessionRepository, AttendanceSessionRepository>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

// Handlers
builder.Services.AddScoped<CreateParishHandler>();
builder.Services.AddScoped<CreateStudentHandler>();
builder.Services.AddScoped<CreateTeacherHandler>();
builder.Services.AddScoped<CreateAssistantHandler>();
builder.Services.AddScoped<CreateCatechismClassHandler>();
builder.Services.AddScoped<CreateSacramentHandler>();
builder.Services.AddScoped<CreateCatechismGradeHandler>();
builder.Services.AddScoped<CreateAcademicYearHandler>();
builder.Services.AddScoped<CreateAttendanceSessionHandler>();
builder.Services.AddScoped<CreateAttendanceHandler>();
builder.Services.AddScoped<GetSacramentByIdHandler>();

builder.Services.AddScoped<CreateSemesterHandler>();

// Controllers
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();