namespace Application.Features.Exams.CreateExam;

public class CreateExamResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateExamResponse? Data { get; set; }
}