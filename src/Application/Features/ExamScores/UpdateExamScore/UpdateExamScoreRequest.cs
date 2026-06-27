namespace Application.Features.ExamScores.UpdateExamScore;

public class UpdateExamScoreRequest
{
    public Guid Id { get; set; }

    public Guid ExamId { get; set; }

    public Guid StudentId { get; set; }

    public decimal Score { get; set; }

    public string? Note { get; set; }
}