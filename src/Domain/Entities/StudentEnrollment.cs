using Domain.Common;

namespace Domain.Entities;

public class StudentEnrollment : BaseEntity
{
    public Guid StudentId { get; set; }

    public Guid CatechismClassId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? LeaveDate { get; set; }

    public bool IsCurrent { get; set; } = true;

    public string? Note { get; set; }

    // Navigation
    public Student Student { get; set; } = null!;

    public CatechismClass CatechismClass { get; set; } = null!;
}