using System.ComponentModel.DataAnnotations;

namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public class CreateAttendanceSessionRequest
{
    [Required]
    public Guid AssignmentId { get; set; }

    [Required]
    public DateOnly AttendanceDate { get; set; }

    [Range(1, 100)]
    public int LessonNumber { get; set; }

    [MaxLength(300)]
    public string? Topic { get; set; }
}