using System.Text.Json;
using Application.Common.ApiResponse;
using Application.Common.Exceptions;

namespace WebApi.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = StatusCodes.Status500InternalServerError;

        object response;

        switch (exception)
        {
            case NotFoundException:
                statusCode = StatusCodes.Status404NotFound;

                response = ApiResponse<object>.Fail(exception.Message);
                break;

            case ValidationException validationException:

                statusCode = StatusCodes.Status400BadRequest;

                response = new ApiResponse<object>
                {
                    Success = false,
                    Message = validationException.Message,
                    Errors = validationException.Errors
                };

                break;

            case BusinessException:

                statusCode = StatusCodes.Status400BadRequest;

                response = ApiResponse<object>.Fail(exception.Message);

                break;

            default:

                response = ApiResponse<object>.Fail(exception.Message);

                break;
        }

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}