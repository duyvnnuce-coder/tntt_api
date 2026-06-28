using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using WebApi.Middlewares;
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
using Application.Features.Students.GetStudentList;
using Application.Features.Students.UpdateStudent;
using Application.Features.Students.DeleteStudent;
using Application.Features.Teachers.GetTeacherList;
using Application.Features.Teachers.UpdateTeacher;
using Application.Features.Teachers.DeleteTeacher;
using Application.Features.Assistants.GetAssistantById;
using Application.Features.Assistants.GetAssistantList;
using Application.Features.Assistants.UpdateAssistant;
using Application.Features.Assistants.DeleteAssistant;
using Application.Features.Parishes.GetParishById;
using Application.Features.Parishes.GetParishList;
using Application.Features.Parishes.UpdateParish;
using Application.Features.Parishes.DeleteParish;
using Application.Features.AcademicYears.GetAcademicYearById;
using Application.Features.AcademicYears.GetAcademicYearList;
using Application.Features.AcademicYears.UpdateAcademicYear;
using Application.Features.AcademicYears.DeleteAcademicYear;
using Application.Features.Semesters.GetSemesterList;
using Application.Features.Semesters.GetSemesterById;
using Application.Features.Semesters.UpdateSemester;
using Application.Features.Semesters.DeleteSemester;
using Application.Features.ExamBlueprints.DeleteExamBlueprint;
using Application.Features.CatechismGrades.GetCatechismGradeList;
using Application.Features.CatechismGrades.GetCatechismGradeById;
using Application.Features.CatechismGrades.UpdateCatechismGrade;
using Application.Features.CatechismGrades.DeleteCatechismGrade;
using Application.Features.CatechismClasses.GetCatechismClassList;
using Application.Features.CatechismClasses.GetCatechismClassById;
using Application.Features.CatechismClasses.UpdateCatechismClass;
using Application.Features.CatechismClasses.DeleteCatechismClass;
using Application.Features.AttendanceSessions.GetAttendanceSessionList;
using Application.Features.AttendanceSessions.GetAttendanceSessionById;
using Application.Features.AttendanceSessions.UpdateAttendanceSession;
using Application.Features.AttendanceSessions.DeleteAttendanceSession;
using Application.Features.Attendances.GetAttendanceList;
using Application.Features.Attendances.GetAttendanceById;
using Application.Features.Attendances.UpdateAttendance;
using Application.Features.Attendances.DeleteAttendance;
using Application.Features.StudentEnrollments.DeleteStudentEnrollment;
using Application.Features.Questions.CreateQuestion;
using Application.Features.Questions.GetQuestionList;
using Application.Features.Questions.GetQuestionById;
using Application.Features.Questions.UpdateQuestion;
using Application.Features.Questions.DeleteQuestion;
using Application.Features.QuestionCategories.DeleteQuestionCategory;
using Application.Features.ExamBlueprintDetails.DeleteExamBlueprintDetail;
using Application.Features.Exams.DeleteExam;
using Application.Features.GeneratedExams.DeleteGeneratedExam;
using Application.Features.ExamScores.DeleteExamScore;









var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddScoped<IApplicationDbContext>(sp =>
    sp.GetRequiredService<AppDbContext>());

builder.Services.AddScoped<DeleteExamBlueprintDetailHandler>();
// Repository
builder.Services.AddInfrastructure(builder.Configuration);



// Controllers
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//get
builder.Services.AddScoped<DeleteExamHandler>();

builder.Services.AddScoped<GetSacramentListHandler>();
builder.Services.AddScoped<GetStudentListHandler>();
builder.Services.AddScoped<UpdateStudentHandler>();
builder.Services.AddScoped<DeleteStudentHandler>();
builder.Services.AddScoped<GetTeacherListHandler>();
builder.Services.AddScoped<UpdateTeacherHandler>();
builder.Services.AddScoped<DeleteTeacherHandler>();
builder.Services.AddScoped<GetAssistantByIdHandler>();
builder.Services.AddScoped<GetAssistantListHandler>();
builder.Services.AddScoped<UpdateAssistantHandler>();
builder.Services.AddScoped<DeleteAssistantHandler>();
builder.Services.AddScoped<GetParishByIdHandler>();
builder.Services.AddScoped<GetParishListHandler>();
builder.Services.AddScoped<UpdateParishHandler>();
builder.Services.AddScoped<DeleteParishHandler>();
builder.Services.AddScoped<GetAcademicYearByIdHandler>();
builder.Services.AddScoped<GetAcademicYearListHandler>();
builder.Services.AddScoped<UpdateAcademicYearHandler>();
builder.Services.AddScoped<DeleteAcademicYearHandler>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();
builder.Services.AddScoped<ICatechismGradeRepository, CatechismGradeRepository>();
builder.Services.AddScoped<UpdateExamBlueprintHandler>();
builder.Services.AddScoped<DeleteExamBlueprintHandler>();




builder.Services.AddScoped<CreateCatechismGradeHandler>();
builder.Services.AddScoped<DeleteStudentEnrollmentHandler>();
builder.Services.AddScoped<GetCatechismGradeListHandler>();
builder.Services.AddScoped<DeleteStudentEnrollmentHandler>();
builder.Services.AddScoped<GetCatechismGradeByIdHandler>();

builder.Services.AddScoped<UpdateCatechismGradeHandler>();

builder.Services.AddScoped<DeleteCatechismGradeHandler>();
builder.Services.AddScoped<GetSemesterListHandler>();
builder.Services.AddScoped<GetSemesterByIdHandler>();
builder.Services.AddScoped<UpdateSemesterHandler>();
builder.Services.AddScoped<DeleteSemesterHandler>();
builder.Services.AddScoped<CreateCatechismClassHandler>();

builder.Services.AddScoped<GetCatechismClassListHandler>();

builder.Services.AddScoped<GetCatechismClassByIdHandler>();

builder.Services.AddScoped<UpdateCatechismClassHandler>();

builder.Services.AddScoped<DeleteCatechismClassHandler>();
builder.Services.AddScoped<CreateAttendanceSessionHandler>();

builder.Services.AddScoped<GetAttendanceSessionListHandler>();

builder.Services.AddScoped<GetAttendanceSessionByIdHandler>();

builder.Services.AddScoped<UpdateAttendanceSessionHandler>();

builder.Services.AddScoped<DeleteAttendanceSessionHandler>();
builder.Services.AddScoped<CreateAttendanceHandler>();

builder.Services.AddScoped<GetAttendanceListHandler>();

builder.Services.AddScoped<GetAttendanceByIdHandler>();

builder.Services.AddScoped<UpdateAttendanceHandler>();

builder.Services.AddScoped<DeleteAttendanceHandler>();
builder.Services.AddScoped<CreateQuestionCategoryHandler>();

builder.Services.AddScoped<GetQuestionCategoryListHandler>();

builder.Services.AddScoped<GetQuestionCategoryByIdHandler>();

builder.Services.AddScoped<UpdateQuestionCategoryHandler>();

builder.Services.AddScoped<DeleteQuestionCategoryHandler>();
builder.Services.AddScoped<CreateQuestionHandler>();

builder.Services.AddScoped<GetQuestionListHandler>();

builder.Services.AddScoped<GetQuestionByIdHandler>();

builder.Services.AddScoped<UpdateQuestionHandler>();

builder.Services.AddScoped<DeleteQuestionHandler>();












var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();