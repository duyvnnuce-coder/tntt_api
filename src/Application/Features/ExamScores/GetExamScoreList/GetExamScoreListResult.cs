namespace Application.Features.ExamScores.GetExamScoreList;

public class GetExamScoreListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetExamScoreListResponse> Data { get; set; } = [];
}