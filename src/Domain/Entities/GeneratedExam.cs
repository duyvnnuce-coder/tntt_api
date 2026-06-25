using Domain.Common;

namespace Domain.Entities;

public class GeneratedExam : BaseEntity
{
    public Guid ExamBlueprintId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime GeneratedAt { get; set; }

    public bool IsPublished { get; set; }

    // Navigation
    public ExamBlueprint ExamBlueprint { get; set; } = null!;
}