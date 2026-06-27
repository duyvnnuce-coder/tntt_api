namespace Application.Features.ExamScores.CreateExamScore;

public class CreateExamScoreResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateExamScoreResponse? Data { get; set; }
}