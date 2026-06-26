namespace Application.Features.Teachers.CreateTeacher;

public class CreateTeacherResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateTeacherResponse? Data { get; set; }
}