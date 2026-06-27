namespace Application.Features.Students.GetStudentById;

public class GetStudentByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetStudentByIdResponse? Data { get; set; }
}