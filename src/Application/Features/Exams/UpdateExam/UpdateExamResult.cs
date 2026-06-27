namespace Application.Features.Exams.UpdateExam;

public class UpdateExamResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateExamResponse? Data { get; set; }
}