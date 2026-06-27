namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public class CreateAttendanceSessionResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateAttendanceSessionResponse? Data { get; set; }
}