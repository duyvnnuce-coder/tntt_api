namespace Application.Features.Attendances.CreateAttendance;

public class CreateAttendanceResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateAttendanceResponse? Data { get; set; }
}