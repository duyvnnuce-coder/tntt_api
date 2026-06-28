namespace Application.Features.AttendanceSessions.UpdateAttendanceSession;

public class UpdateAttendanceSessionRequest
{
    public Guid Id { get; set; }

    public Guid AssignmentId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public int LessonNumber { get; set; }

    public string? Topic { get; set; }

    public bool IsLocked { get; set; }
}