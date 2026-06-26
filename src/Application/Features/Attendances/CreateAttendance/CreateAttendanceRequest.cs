using System.ComponentModel.DataAnnotations;

namespace Application.Features.Attendances.CreateAttendance;

public class CreateAttendanceRequest
{
    [Required]
    public Guid AttendanceSessionId { get; set; }

    [Required]
    public Guid StudentId { get; set; }

    public bool IsPresent { get; set; }

    public bool IsExcused { get; set; }

    public string? Note { get; set; }
}