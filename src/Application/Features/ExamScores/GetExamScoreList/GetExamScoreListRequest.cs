namespace Application.Features.ExamScores.GetExamScoreList;

public class GetExamScoreListRequest
{
    public string? Keyword { get; set; }

    public Guid? ExamId { get; set; }

    public Guid? StudentId { get; set; }
}