namespace Application.Features.Attendances.GetAttendanceById;

public class GetAttendanceByIdResponse
{
    public Guid Id { get; set; }

    public Guid AttendanceSessionId { get; set; }

    public Guid StudentId { get; set; }

    public bool IsPresent { get; set; }

    public bool IsExcused { get; set; }

    public string? Note { get; set; }
}