using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICodeGenerator, CodeGenerator>();

        return services;
    }
}