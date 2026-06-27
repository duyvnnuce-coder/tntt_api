namespace Application.Features.ExamScores.CreateExamScore;

public class CreateExamScoreRequest
{
    public Guid ExamId { get; set; }

    public Guid StudentId { get; set; }

    public decimal Score { get; set; }

    public string? Note { get; set; }
}