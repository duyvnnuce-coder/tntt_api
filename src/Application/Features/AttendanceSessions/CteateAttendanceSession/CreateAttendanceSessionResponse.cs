namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public class CreateAttendanceSessionResponse
{
    public Guid Id { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public int LessonNumber { get; set; }
}