using Domain.Common;

namespace Domain.Entities;

public class Assignment : BaseEntity
{
    public Guid TeacherId { get; set; }

    public Guid? AssistantId { get; set; }

    public Guid ClassId { get; set; }

    public Guid SemesterId { get; set; }

    public bool IsMainTeacher { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Note { get; set; }

    // Navigation
    public Teacher Teacher { get; set; } = null!;

    public Assistant? Assistant { get; set; }

    public CatechismClass Class { get; set; } = null!;

    public Semester Semester { get; set; } = null!;
}