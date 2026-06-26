namespace Application.Features.Semesters.CreateSemester;

public class CreateSemesterResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateSemesterResponse? Data { get; set; }
}