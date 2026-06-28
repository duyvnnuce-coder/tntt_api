namespace Application.Features.AttendanceSessions.GetAttendanceSessionById;

public class GetAttendanceSessionByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetAttendanceSessionByIdResponse? Data { get; set; }
}