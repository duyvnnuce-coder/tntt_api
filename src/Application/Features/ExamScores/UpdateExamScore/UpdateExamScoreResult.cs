namespace Application.Features.ExamScores.UpdateExamScore;

public class UpdateExamScoreResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateExamScoreResponse? Data { get; set; }
}