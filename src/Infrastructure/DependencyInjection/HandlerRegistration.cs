using Application.Features.Students.CreateStudent;
using Application.Features.Students.GetStudentById;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class HandlerRegistration
{
    public static IServiceCollection AddHandlers(
        this IServiceCollection services)
    {
        services.AddScoped<CreateStudentHandler>();

        services.AddScoped<GetStudentByIdHandler>();

        return services;
    }
}