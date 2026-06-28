namespace Application.Features.ExamScores.GetExamScoreList;

public class GetExamScoreListResponse
{
    public Guid Id { get; set; }

    public Guid ExamId { get; set; }

    public string ExamName { get; set; } = string.Empty;

    public Guid StudentId { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public string? Note { get; set; }
}