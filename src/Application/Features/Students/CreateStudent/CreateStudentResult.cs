namespace Application.Features.Students.CreateStudent;

public class CreateStudentResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateStudentResponse? Data { get; set; }
}