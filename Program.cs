using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Infrastructure.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Application.Features.Students.CreateStudent;
using Application.Features.Parishes.CreateParish;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

// Repositories
builder.Services.AddScoped<ICatechismClassRepository, CatechismClassRepository>();
builder.Services.AddScoped<IParishRepository, ParishRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
builder.Services.AddScoped<IStudentCardRepository, StudentCardRepository>();
builder.Services.AddScoped<CreateParishHandler>();
// Services
builder.Services.AddScoped<ICodeGenerator, CodeGenerator>();

// Handlers
builder.Services.AddScoped<CreateStudentHandler>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();