using System.ComponentModel.DataAnnotations;

namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public class CreateAttendanceSessionRequest
{
    [Required]
    public Guid AssignmentId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public int LessonNumber { get; set; }

    [MaxLength(200)]
    public string? Topic { get; set; }

    public bool IsLocked { get; set; }
}