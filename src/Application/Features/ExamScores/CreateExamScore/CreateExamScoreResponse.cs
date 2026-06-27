namespace Application.Features.ExamScores.CreateExamScore;

public class CreateExamScoreResponse
{
    public Guid Id { get; set; }

    public Guid ExamId { get; set; }

    public string ExamCode { get; set; } = string.Empty;

    public Guid StudentId { get; set; }

    public string StudentCode { get; set; } = string.Empty;

    public string StudentName { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public string? Note { get; set; }
}