namespace Application.Features.StudentEnrollments.GetStudentEnrollmentList;

public class GetStudentEnrollmentListResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public string StudentCode { get; set; } = string.Empty;

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public Guid CatechismClassId { get; set; }

    public string CatechismClassCode { get; set; } = string.Empty;

    public string CatechismClassName { get; set; } = string.Empty;

    public DateOnly JoinDate { get; set; }

    public DateOnly? LeaveDate { get; set; }

    public bool IsCurrent { get; set; }

    public string? Note { get; set; }
}