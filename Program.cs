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
using Application.Features.Sacraments.GetSacramentList;
using Application.Features.StudentCards.CreateStudentCard;
using Application.Features.StudentCards.GetStudentCardById;
using Application.Features.StudentCards.GetStudentCardList;
using Application.Features.StudentCards.GetStudentCardByStudentId;
using Application.Features.StudentCards.UpdateStudentCardStatus;
using Application.Features.StudentCards.ReissueStudentCard;
using Application.Features.StudentEnrollments.CreateStudentEnrollment;
using Application.Features.StudentEnrollments.GetStudentEnrollmentById;
using Application.Features.StudentEnrollments.GetStudentEnrollmentList;
using Application.Features.StudentEnrollments.UpdateStudentEnrollment;
using Application.Features.QuestionCategories.CreateQuestionCategory;
using Application.Features.QuestionCategories.GetQuestionCategoryById;
using Application.Features.QuestionCategories.GetQuestionCategoryList;
using Application.Features.QuestionCategories.UpdateQuestionCategory;
using Application.Features.Questions.CreateQuestion;
using Application.Features.Questions.GetQuestionById;
using Application.Features.Questions.GetQuestionList;
using Application.Features.Questions.UpdateQuestion;
using Application.Features.ExamBlueprints.CreateExamBlueprint;
using Application.Features.ExamBlueprints.GetExamBlueprintById;
using Application.Features.ExamBlueprints.GetExamBlueprintList;
using Application.Features.ExamBlueprints.UpdateExamBlueprint;
using Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;
using Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;
using Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;
using Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;
using Application.Features.Exams.CreateExam;
using Application.Features.Exams.GetExamById;
using Application.Features.Exams.GetExamList;
using Application.Features.Exams.UpdateExam;
using Application.Features.ExamScores.CreateExamScore;
using Application.Features.ExamScores.GetExamScoreById;
using Application.Features.ExamScores.GetExamScoreList;
using Application.Features.ExamScores.UpdateExamScore;
using Application.Features.GeneratedExams.CreateGeneratedExam;
using Application.Features.GeneratedExams.GetGeneratedExamById;
using Application.Features.GeneratedExams.GetGeneratedExamList;
using Application.Features.GeneratedExams.UpdateGeneratedExam;


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
builder.Services.AddScoped<IExamBlueprintRepository, ExamBlueprintRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
builder.Services.AddScoped<IStudentCardRepository, StudentCardRepository>();
builder.Services.AddScoped<ICatechismGradeRepository, CatechismGradeRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAssistantRepository, AssistantRepository>();
builder.Services.AddScoped<ISacramentRepository, SacramentRepository>();
builder.Services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IExamBlueprintDetailRepository, ExamBlueprintDetailRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamScoreRepository, ExamScoreRepository>();
builder.Services.AddScoped<IGeneratedExamRepository, GeneratedExamRepository>();


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
builder.Services.AddScoped<CreateStudentCardHandler>();
builder.Services.AddScoped<GetStudentCardListHandler>();
builder.Services.AddScoped<GetStudentCardByStudentIdHandler>();
builder.Services.AddScoped<UpdateStudentCardStatusHandler>();
builder.Services.AddScoped<ReissueStudentCardHandler>();
builder.Services.AddScoped<GetStudentCardByIdHandler>();
builder.Services.AddScoped<CreateSemesterHandler>();
builder.Services.AddScoped<CreateStudentEnrollmentHandler>();
builder.Services.AddScoped<GetStudentEnrollmentByIdHandler>();
builder.Services.AddScoped<GetStudentEnrollmentListHandler>();
builder.Services.AddScoped<UpdateStudentEnrollmentHandler>();
builder.Services.AddScoped<CreateQuestionCategoryHandler>();
builder.Services.AddScoped<GetQuestionCategoryByIdHandler>();
builder.Services.AddScoped<GetQuestionCategoryListHandler>();
builder.Services.AddScoped<UpdateQuestionCategoryHandler>();
builder.Services.AddScoped<CreateQuestionHandler>();
builder.Services.AddScoped<GetQuestionByIdHandler>();
builder.Services.AddScoped<GetQuestionListHandler>();
builder.Services.AddScoped<UpdateQuestionHandler>();
builder.Services.AddScoped<CreateExamBlueprintHandler>();
builder.Services.AddScoped<GetExamBlueprintByIdHandler>();
builder.Services.AddScoped<GetExamBlueprintListHandler>();
builder.Services.AddScoped<UpdateExamBlueprintHandler>();
builder.Services.AddScoped<IExamBlueprintDetailRepository, ExamBlueprintDetailRepository>();
builder.Services.AddScoped<CreateExamHandler>();
builder.Services.AddScoped<GetExamByIdHandler>();
builder.Services.AddScoped<GetExamListHandler>();
builder.Services.AddScoped<UpdateExamHandler>();
builder.Services.AddScoped<CreateExamScoreHandler>();
builder.Services.AddScoped<GetExamScoreByIdHandler>();
builder.Services.AddScoped<GetExamScoreListHandler>();
builder.Services.AddScoped<UpdateExamScoreHandler>();
builder.Services.AddScoped<CreateGeneratedExamHandler>();
builder.Services.AddScoped<GetGeneratedExamByIdHandler>();
builder.Services.AddScoped<GetGeneratedExamListHandler>();
builder.Services.AddScoped<UpdateGeneratedExamHandler>();




// Controllers
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//get
builder.Services.AddScoped<GetSacramentListHandler>();


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