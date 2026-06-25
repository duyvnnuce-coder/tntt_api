using Domain.Common;

namespace Domain.Entities;

public class ExamBlueprint : BaseEntity
{
    public Guid CatechismGradeId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int TotalQuestions { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; }

    // Navigation
    public CatechismGrade CatechismGrade { get; set; } = null!;
}