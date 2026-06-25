using Domain.Common;

namespace Domain.Entities;

public class Attendance : BaseEntity
{
    public Guid AttendanceSessionId { get; set; }

    public Guid StudentId { get; set; }

    public bool IsPresent { get; set; }

    public bool IsExcused { get; set; }

    public string? Note { get; set; }

    // Navigation
    public AttendanceSession AttendanceSession { get; set; } = null!;

    public Student Student { get; set; } = null!;
}