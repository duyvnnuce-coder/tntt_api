namespace Application.Features.ExamScores.GetExamScoreById;

public class GetExamScoreByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetExamScoreByIdResponse? Data { get; set; }
}