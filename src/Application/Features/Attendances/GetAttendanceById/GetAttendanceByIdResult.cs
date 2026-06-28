namespace Application.Features.Attendances.GetAttendanceById;

public class GetAttendanceByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetAttendanceByIdResponse? Data { get; set; }
}