namespace Application.Features.Attendances.CreateAttendance;

public class CreateAttendanceResponse
{
    public Guid Id { get; set; }

    public Guid AttendanceSessionId { get; set; }

    public Guid StudentId { get; set; }

    public bool IsPresent { get; set; }

    public bool IsExcused { get; set; }
}