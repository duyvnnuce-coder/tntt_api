using Domain.Common;

namespace Domain.Entities;

public class AttendanceSession : BaseEntity
{
    public Guid AssignmentId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public int LessonNumber { get; set; }

    public string? Topic { get; set; }

    public bool IsLocked { get; set; }

    // Navigation
    public Assignment Assignment { get; set; } = null!;
}