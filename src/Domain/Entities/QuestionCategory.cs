using Domain.Common;

namespace Domain.Entities;

public class QuestionCategory : BaseEntity
{
    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    // Navigation
    public Parish Parish { get; set; } = null!;
}