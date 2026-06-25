using Domain.Common;

namespace Domain.Entities;

public class Exam : BaseEntity
{
    public Guid AssignmentId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateOnly ExamDate { get; set; }

    public decimal MaxScore { get; set; }

    public bool IsPublished { get; set; }

    // Navigation
    public Assignment Assignment { get; set; } = null!;
}