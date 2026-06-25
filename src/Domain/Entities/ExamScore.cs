using Domain.Common;

namespace Domain.Entities;

public class ExamScore : BaseEntity
{
    public Guid ExamId { get; set; }

    public Guid StudentId { get; set; }

    public decimal Score { get; set; }

    public string? Note { get; set; }

    // Navigation
    public Exam Exam { get; set; } = null!;

    public Student Student { get; set; } = null!;
}